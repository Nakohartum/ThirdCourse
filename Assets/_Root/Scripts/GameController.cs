using System;
using _Root.Scripts.Bonus;
using _Root.Scripts.Camera;
using _Root.Scripts.Interfaces;
using _Root.Scripts.Player;
using _Root.Scripts.Player.Controller;
using _Root.Scripts.References;
using _Root.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Root.Scripts
{
    public class GameController : MonoBehaviour, IDisposable
    {
        public PlayerType PlayerType = PlayerType.Ball;
        private ListExecutableObject _interactiveObjects;
        private DisplayEndGame _displayEndGame;
        private DisplayBonuses _displayBonuses;
        private CameraController _cameraController;
        private InputController _inputController;
        private int _countBonuses = 0;
        private Reference _reference;

        private void Awake()
        {
            _interactiveObjects = new ListExecutableObject();
            _reference = new Reference();
            PlayerBase player = null;
            if (PlayerType == PlayerType.Ball)
            {
                player = _reference.PlayerBall;
            }
            
            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _interactiveObjects.AddExecuteObject(_cameraController);

            _inputController = new InputController(player); 
            _interactiveObjects.AddExecuteObject(_inputController);
            
            
            _displayEndGame = new DisplayEndGame(_reference.DisplayText);
            _displayBonuses = new DisplayBonuses(_reference.DisplayText);
            foreach (IExecute o in _interactiveObjects)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange += CaughtPlayer;
                    badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange += AddBonus;
                }
            }
            
            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1f;
        }

        private void AddBonus(int obj)
        {
            _countBonuses += obj;
            _displayBonuses.Display(_countBonuses);
        }

        private void CaughtPlayer(string value, Color args)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            for (int i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];
                if (interactiveObject == null)
                {
                    continue;
                }

                interactiveObject.Execute(deltaTime);
            }
        }

        public void Dispose()
        {
            foreach (IExecute o in _interactiveObjects)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                    badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                }

                if (o is GoodBonus goodBonus)
                {
                    goodBonus.OnPointChange -= AddBonus;
                }
            }
        }
    }
}
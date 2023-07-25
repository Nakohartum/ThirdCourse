using _Root.Scripts.Interfaces;
using _Root.Scripts.SaveSystem;
using UnityEngine;

namespace _Root.Scripts.Player.Controller
{
    public class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;

        public InputController(PlayerBase playerBase)
        {
            _playerBase = playerBase;
            _saveDataRepository = new SaveDataRepository();
        }

        public void Execute(float deltaTime)
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(_savePlayer))
            {
                _saveDataRepository.Save(_playerBase);
            }

            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(_playerBase);
            }
        }
    }
}
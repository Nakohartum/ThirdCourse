using _Root.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Scripts.References
{
    public class Reference
    {
        private PlayerBall _playerBall;
        private UnityEngine.Camera _mainCamera;
        private GameObject _displayText;
        private Canvas _canvas;
        private Button _restartButton;

        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<Player.PlayerBall>("Player");
                    _playerBall = Object.Instantiate(gameObject);
                }

                return _playerBall;
            }
        }

        public UnityEngine.Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = UnityEngine.Camera.main;
                }

                return _mainCamera;
            }
        }

        public GameObject DisplayText
        {
            get
            {
                if (_displayText == null)
                {
                    var go = Resources.Load<GameObject>("UI/DisplayText");
                    _displayText = Object.Instantiate(go, Canvas.transform);
                }

                return _displayText;
            }
        }

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }

                return _canvas;
            }
        }
        
        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var button = Resources.Load<Button>("UI/RestartGame");
                    _restartButton = Object.Instantiate(button, Canvas.transform);
                }

                return _restartButton;
            }
        }
    }
}
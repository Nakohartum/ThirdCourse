using _Root.Scripts.Interfaces;
using UnityEngine;

namespace _Root.Scripts.Player.Controller
{
    public class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;

        public InputController(PlayerBase playerBase)
        {
            _playerBase = playerBase;
        }

        public void Execute(float deltaTime)
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        }
    }
}
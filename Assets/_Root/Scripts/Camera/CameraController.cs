using System;
using _Root.Scripts.Interfaces;
using UnityEngine;

namespace _Root.Scripts.Camera
{
    public class CameraController : IExecute
    {
        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _offset = _mainCamera.position - _player.position;
            _mainCamera.LookAt(_player);
        }


        public void Execute(float deltaTime)
        {
            _mainCamera.position = _player.position + _offset;
        }
    }
}
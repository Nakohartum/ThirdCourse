using System;
using _Root.Scripts.Bonus;
using _Root.Scripts.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Root.Scripts
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        protected Color _color;
        private bool _isInteractable;
        public bool IsInteractable
        {
            get => _isInteractable;
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }
        public abstract void Interaction();
        public abstract void Execute(float deltaTime);

        private void Start()
        {
            IsInteractable = true;
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            IsInteractable = false;
        }
    }
}
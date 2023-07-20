using System;
using UnityEngine;
using static UnityEngine.Random;
using static UnityEngine.Mathf;
using static UnityEngine.Time;

namespace _Root.Scripts.Bonus
{
    public class BadBonus : InteractiveObject, IFlay, IRotation
    {
        public event Action<string, Color> OnCaughtPlayerChange = (s, color) => { };
        private float _lengthFlay;
        private float _speedRotation;
        private void Awake()
        {
            _lengthFlay = Range(1.0f, 5.0f);
            _speedRotation = Range(10.0f, 50.0f);
        }

        public override void Interaction()
        {
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);
        }

        public override void Execute(float deltaTime)
        {
            if (!IsInteractable)
            {
                return;
            }
            Flay();
            Rotation();
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, PingPong(time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (deltaTime * _speedRotation), Space.World);
        }
    }
}
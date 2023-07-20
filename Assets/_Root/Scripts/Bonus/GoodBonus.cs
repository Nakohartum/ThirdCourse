using System;
using _Root.Scripts.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Root.Scripts.Bonus
{
    public class GoodBonus : InteractiveObject, IFlay, IFlicker
    {
        public int Point;
        public event Action<int> OnPointChange = i => { };
        private Material _material;
        private float _lengthFlay;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1.0f, 5.0f);
        }

        public override void Interaction()
        {
            OnPointChange.Invoke(Point);
        }

        public override void Execute(float deltaTime)
        {
            if (!IsInteractable)
            {
                return;
            }

            Flay();
            Flicker();
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}
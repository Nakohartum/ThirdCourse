using System.Collections;
using UnityEngine;

namespace _Root.Scripts.Bonus
{
    public class ListInteractiveObject : IEnumerator, IEnumerable
    {
        private InteractiveObject[] _interactiveObjects;
        private int _index = -1;
        public object Current => _interactiveObjects[_index];
        public int Length => _interactiveObjects.Length;

        public ListInteractiveObject()
        {
            _interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
        }

        public InteractiveObject this[int index]
        {
            get => _interactiveObjects[index];
            set => _interactiveObjects[index] = value;
        }


        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }


        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
using System;
using System.Collections;
using Object = UnityEngine.Object;

namespace _Root.Scripts.Interfaces
{
    public class ListExecutableObject : IEnumerator, IEnumerable
    {
        private IExecute[] _interactiveObjects;
        private int _index = -1;
        private InteractiveObject _current;

        public IExecute this[int index]
        {
            get => _interactiveObjects[index];
            private set => _interactiveObjects[index] = value;
        }

        public int Length => _interactiveObjects.Length;

        public object Current => _interactiveObjects[_index];

        public ListExecutableObject()
        {
            var interactiveObjects = Object.FindObjectsOfType<InteractiveObject>();
            for (int i = 0; i < interactiveObjects.Length; i++)
            {
                if (interactiveObjects[i] is IExecute interactiveObject)
                {
                    AddExecuteObject(interactiveObject);
                }
            }
        }

        public void AddExecuteObject(IExecute execute)
        {
            if (_interactiveObjects == null)
            {
                _interactiveObjects = new[] {execute};
                return;
            }
            Array.Resize(ref _interactiveObjects, Length + 1);
            _interactiveObjects[Length - 1] = execute;
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

        public void Reset() => _index = -1;

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
using System;
using UnityEngine;

namespace EventSystem
{
    public class EventWithParameter<T>
    {
        private event Action<T> _action = delegate { };
        public void Invoke(T param) { _action.Invoke(param); }
        public void AddListener(Action<T> listener) { _action -= listener;  _action += listener; }
        public void DeleteListener(Action<T> listener) { _action -= listener; }
    }
}
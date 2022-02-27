using System;

namespace EventSystem
{
    public class Event
    {
        private event Action _action = delegate { };

        public void Invoke() { _action.Invoke(); }
        public void AddListener(Action listener) { _action -= listener;  _action += listener; }
        public void DeleteListener(Action listener) { _action -= listener; }
    }
}
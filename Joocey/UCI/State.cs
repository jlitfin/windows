using System;
using System.Collections.Generic;
using System.Linq;

namespace UCI
{
    public class State
    {
        private Dictionary<string, object> _state = new Dictionary<string, object>();

        public State(IEnumerable<string> keys)
        {
            foreach (var k in keys)
            {
                if (!_state.ContainsKey(k))
                    _state.Add(k, null);
            }
        }

        public event EventHandler<StateChangeEventArgs> StateChanged;
        public void OnStateChanged(StateChangeEventArgs e)
        {
            (StateChanged as EventHandler<StateChangeEventArgs>)?.Invoke(this, e);
        }

        private Dictionary<string, object> Get()
        {
            return _state.ToDictionary(k => k.Key, v => v.Value);
        }

        public void Initialize(string key, object value)
        {
            _state[key] = value;
        }

        public object Get(string key)
        {
            return _state[key];
        }

        public void Set(string key, object value)
        {
            var e = new StateChangeEventArgs
            {
                Keys = new List<string> { key },
                Prior = Get()
            };

            _state[key] = value;
            e.Current = Get();

            OnStateChanged(e);
        }

        public void Set(Dictionary<string, object> delta)
        {
            var e = new StateChangeEventArgs
            {
                Keys = new List<string>(),
                Prior = Get()
            };

            foreach (var k in delta.Keys)
            {
                if (delta[k] != e.Prior[k])
                    e.Keys.Add(k);

                _state[k] = delta[k];
            }
            e.Current = Get();

            OnStateChanged(e);
        }
    }

    public class StateKeyValue
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }

    public class StateChangeEventArgs : EventArgs
    {
        public List<string> Keys { get; set; }
        public Dictionary<string, object> Prior { get; set; }
        public Dictionary<string, object> Current { get; set; }
    }

    public class StateKeys
    {
        public const string AwaitResponse = "AwaitResponse";
        public const string Buffer = "Buffer";
        public const string Connected = "Connected";
        public const string Initialized = "Initialized";
        public const string Ready = "Ready";
        public const string Sent = "Sent";
        public const string Reply = "Reply";
        public const string IsErrorState = "IsErrorState";
        public const string SetKey = "SetKey";
    }
}

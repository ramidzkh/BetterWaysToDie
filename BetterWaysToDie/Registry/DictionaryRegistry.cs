using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace BetterWaysToDie.Registry
{
    internal class DictionaryRegistry<T> : IRegistry<T>
    {
        private readonly IDictionary<string, T> _dictionary_a2b = new Dictionary<string, T>();
        private readonly IDictionary<T, string> _dictionary_b2a = new Dictionary<T, string>();

        public T this[string name]
        {
            get
            {
                if (_dictionary_a2b.ContainsKey(name))
                {
                    return _dictionary_a2b[name];
                }

                Debug.LogWarning($"Tried to get entry with name {name} but it is not registered");
                throw new InvalidOperationException($"Tried to get entry with name {name} but it is not registered");
            }
            set
            {
                if (_dictionary_a2b.ContainsKey(name))
                {
                    throw new DuplicateNameException(
                        $"Tried to register with name {name} but it is already being used");
                }

                _dictionary_a2b[name] = value;
                _dictionary_b2a[value] = name;
            }
        }

        public string Remove(T entry)
        {
            var old = _dictionary_b2a[entry];

            if (_dictionary_b2a.Remove(entry))
            {
                _dictionary_a2b.Remove(old);
                return old;
            }

            throw new InvalidOperationException($"Tried to remove entry {entry} but it is not registered");
        }

        public T Remove(string name)
        {
            var old = _dictionary_a2b[name];

            if (_dictionary_a2b.Remove(name))
            {
                _dictionary_b2a.Remove(old);
                return old;
            }

            throw new InvalidOperationException($"Tried to remove entry with name {name} but it is not registered");
        }

        public string GetId(T entry)
        {
            if (_dictionary_b2a.ContainsKey(entry))
            {
                return _dictionary_b2a[entry];
            }

            throw new InvalidOperationException($"Tried to get id of entry {entry} but it is not registered");
        }

        public bool IsRegistered(T entry)
        {
            return _dictionary_b2a.ContainsKey(entry);
        }

        public bool IsRegistered(string name)
        {
            return _dictionary_a2b.ContainsKey(name);
        }

        public IDictionary<string, T> GetEntries()
        {
            return new Dictionary<string, T>(_dictionary_a2b);
        }
    }
}

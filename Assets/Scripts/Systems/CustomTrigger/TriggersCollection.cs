using Zenject;
using System.Collections.Generic;
using UnityEngine;

namespace Market
{
    public sealed class TriggersCollection<T> : IInitializable
    {
        private readonly SignalBus _signalBus;

        private List<T> _items = new();

        public TriggersCollection(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<TriggerEnteredSignal<T>>(AddItem);
            _signalBus.Subscribe<TriggerExitedSignal<T>>(RemoveItem);
        }


        private void AddItem(TriggerEnteredSignal<T> signal)
        {
            _items.Add(signal.TriggerObject);
            //Debug.Log("Added: " + signal.TriggerObject);
        }

        private void RemoveItem(TriggerExitedSignal<T> signal)
        {
            _items.Remove(signal.TriggerObject);
            //Debug.Log("Removed: " + signal.TriggerObject);
        }

        public T GetItem()
        {
            if (ItemExist())
            {
                return _items[0];
            }
            else
            {
                Debug.LogError($"No trigger items with type{typeof(T)}");
                return default(T);
            }
        }

        public T ExtractItem()
        {
            var result = GetItem();
            _items.RemoveAt(0);
            return result;
        }

        public bool ItemExist()
        {
            return (_items.Count > 0);
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PhotonTestTask
{
    public sealed class CustomTriggerHandler<T> : IDisposable where T : MonoBehaviour
    {
        private readonly SignalBus _signalBus;

        private List<CustomTrigger> _customTriggers = new();
        private List<ITriggerable<T>> _triggerables = new();

        private int _currentIndex = 0;

        public CustomTriggerHandler(SignalBus signalBus, ITriggerable<T>[] triggerables)
        {
            _signalBus = signalBus;
            foreach (var triggerable in triggerables)
            {
                AddTriggerable(triggerable);
            }
        }

        public void AddTriggerable(ITriggerable<T> triggerable)
        {
            _triggerables.Add(triggerable);
            var trigger = triggerable.Component.gameObject.AddComponent<CustomTrigger>();
            trigger.Init(_currentIndex++);
            trigger.Entered += OnTriggerEntered;
            trigger.Exited += OnTriggerExited;
            _customTriggers.Add(trigger);

            triggerable.CustomTrigger =  trigger;
        }

        private void OnTriggerEntered(int index)
        {
            _signalBus.Fire(new TriggerEnteredSignal<T> { TriggerObject = _triggerables[index].Component });
        }

        private void OnTriggerExited(int index)
        {
            _signalBus.Fire(new TriggerExitedSignal<T> { TriggerObject = _triggerables[index].Component });

        }

        public void Dispose()
        {
            for (int i = 0; i < _customTriggers.Count; i++)
            {
                _customTriggers[i].Entered -= OnTriggerEntered;
                _customTriggers[i].Exited -= OnTriggerExited;
            }
        }
    }
}

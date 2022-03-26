using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class IntEvent : UnityEvent<int> { }

namespace MidnightMetalMadness
{
    [CreateAssetMenu(menuName = "Events/Int Event")]
    public class IntEventSO : ScriptableObject
    {
        public UnityAction<int> OnEventRaised;
        public void RaiseEvent(int value)
        {
            OnEventRaised?.Invoke(value);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class BoolEvent : UnityEvent<bool> { }

namespace MidnightMetalMadness
{
    [CreateAssetMenu(menuName = "Events/Bool Event")]
    public class BoolEventSO : ScriptableObject
    {
        public UnityAction<bool> OnEventRaised;
        public void RaiseEvent(bool condition)
        {
            OnEventRaised?.Invoke(condition);
        }
    }
}

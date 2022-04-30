using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class TransformEvent: UnityEvent<Transform> { }

namespace MidnightMetalMadness
{
    [CreateAssetMenu(menuName = "Events/Transform Event")]
    public class TransformEventSO : ScriptableObject
    {
        public UnityAction<Transform> OnEventRaised;
        public void RaiseEvent(Transform obj)
        {
            OnEventRaised?.Invoke(obj);
        }
    }
}

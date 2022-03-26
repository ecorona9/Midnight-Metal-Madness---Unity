using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class SpriteEvent : UnityEvent<Sprite> { }

namespace MidnightMetalMadness
{
    [CreateAssetMenu(menuName = "Events/Sprite Event")]
    public class SpriteEventSO : ScriptableObject
    {
        public UnityAction<Sprite> OnEventRaised;
        public void RaiseEvent(Sprite image)
        {
            OnEventRaised?.Invoke(image);
        }
    }
}

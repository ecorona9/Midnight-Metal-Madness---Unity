using UnityEngine;
using UnityEngine.Events;

namespace MidnightMetalMadness
{
    [CreateAssetMenu(menuName = "Events/Void Event")]
    public class VoidEventSO : ScriptableObject
    {
        public UnityAction OnEventRaised;
        public void RaiseEvent()
        {
            OnEventRaised?.Invoke();
        }
    }
}

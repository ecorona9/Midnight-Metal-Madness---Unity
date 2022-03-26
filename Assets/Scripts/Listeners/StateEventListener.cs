using UnityEngine;
using UnityEngine.Events;

namespace MidnightMetalMadness
{
    public class StateEventListener : MonoBehaviour
    {
        [SerializeField] private VoidEventSO game_over_channel;

        public UnityEvent OnPlayerDeath;

        private void OnEnable()
        {
            game_over_channel.OnEventRaised += TransitionState;
        }

        private void OnDisable()
        {
            game_over_channel.OnEventRaised -= TransitionState;
        }

        public void TransitionState()
        {
            OnPlayerDeath?.Invoke();
        }
    }
}

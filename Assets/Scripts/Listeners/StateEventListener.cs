using UnityEngine;
using UnityEngine.Events;

namespace MidnightMetalMadness
{
    public class StateEventListener : MonoBehaviour
    {
        [SerializeField] private VoidEventSO game_over_channel;
        [SerializeField] private TransformEventSO player_spawn_channel;

        public UnityEvent OnPlayerDeath;
        public TransformEvent OnPlayerSpawn;

        private void OnEnable()
        {
            game_over_channel.OnEventRaised += TransitionState;
            player_spawn_channel.OnEventRaised += GetPlayerTransform;
        }

        private void OnDisable()
        {
            game_over_channel.OnEventRaised -= TransitionState;
            player_spawn_channel.OnEventRaised -= GetPlayerTransform;
        }

        public void TransitionState()
        {
            OnPlayerDeath?.Invoke();
        }

        public void GetPlayerTransform(Transform player)
        {
            OnPlayerSpawn?.Invoke(player);
        }
    }
}

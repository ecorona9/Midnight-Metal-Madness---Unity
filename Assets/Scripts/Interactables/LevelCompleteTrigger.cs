using UnityEngine;

namespace MidnightMetalMadness.Entity.Interactables
{
    public class LevelCompleteTrigger : MonoBehaviour
    {
        [SerializeField] private VoidEventSO level_complete_channel;

        private void OnTriggerEnter2D()
        {
            level_complete_channel?.RaiseEvent();
            Destroy(gameObject);
        }
    }
}

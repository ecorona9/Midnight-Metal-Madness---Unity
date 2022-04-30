using UnityEngine;

namespace MidnightMetalMadness
{
    public class OutOfBounds : MonoBehaviour
    {
        [SerializeField] private VoidEventSO game_over_channel;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                game_over_channel.RaiseEvent();
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

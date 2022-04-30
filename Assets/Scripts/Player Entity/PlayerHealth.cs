/* Summary:
 * PlayerHealth manages the health of the player. Attach this to the parent object of the player
 */
using UnityEngine;

namespace MidnightMetalMadness.Entity.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private PlayerStats player_stats;
        [SerializeField] private IntEventSO player_health_channel;
        [SerializeField] private VoidEventSO game_over_channel;

        private int health;
        private int max_health;

        private void Start()
        {
            health = max_health = player_stats.maximum_health;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Health Changer"))
            {
                int value = collision.gameObject.GetComponent<IHealthChange>().HealthChangeAmount();
                if (value < 0)
                {
                    AudioManager.instance.PlayHurt();
                }
                ChangeHealth(value);
            }
        }

        private void ChangeHealth(int value)
        {
            player_health_channel.RaiseEvent(value);
            health += (value);
            CheckHealth();
        }

        private void CheckHealth()
        {
            if (health <= 0)
            {
                game_over_channel.RaiseEvent();
                gameObject.SetActive(false);
            }
            else if (health > max_health)
            {
                health = max_health;
            } 
        }
    }
}

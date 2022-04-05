/* Summary:
 * 
 * This script manages the health points of the player
 * 
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

        private void Start()
        {
            health = player_stats.maximum_health;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Health Changer"))
            {
                int value = collision.gameObject.GetComponent<IHealthChange>().HealthChangeAmount();
                ChangeHealth(value);
            }
        }

        private void ChangeHealth(int value)
        {
            player_health_channel.RaiseEvent(value);
            health += (value);

            if (health <= 0)
            {
                game_over_channel.RaiseEvent();
                gameObject.SetActive(false);
            }

            if (health > 100)
            {
                health = 100;
            }
        }
    }
}

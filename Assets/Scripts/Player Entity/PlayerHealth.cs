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

        // Low health is below 25% of maxmium health
        private bool is_low_health;

        private void Start()
        {
            health = max_health = player_stats.maximum_health;
            is_low_health = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Health Changer"))
            {
                int value = collision.gameObject.GetComponent<IHealthChange>().HealthChangeAmount();
                Debug.Log(value);
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
            else if (health / (float)max_health <= 0.25f && !is_low_health)
            {
                AudioManager.instance.PlayLowHP();
                is_low_health = true;
            }
            else if (health / (float)max_health > 0.25f && is_low_health)
            {
                AudioManager.instance.PauseLowHP();
                is_low_health = false;
            }
            else if (health > max_health)
            {
                health = max_health;
            } 
        }
    }
}

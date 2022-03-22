/* Summary:
 * 
 * This script manages the health points of the player
 * 
 */
using UnityEngine;
using MidnightMetalMadness.UI;
using MidnightMetalMadness.Entity.Weapons;

namespace MidnightMetalMadness.Entity.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private PlayerStats player_stats;

        [SerializeField] private GameObject damage_text;

        [SerializeField] private IntEventSO player_health_channel;
        [SerializeField] private VoidEventSO game_over_channel;

        private int health;

        private void Start()
        {
            health = player_stats.maximum_health;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Projectiles"))
            {
                int dmg = collision.gameObject.GetComponent<Projectiles>().damage;
                TakeDamage(dmg);
            }
        }

        private void TakeDamage(int dmg)
        {
            player_health_channel.RaiseEvent(dmg);
            health -= dmg;
            SpawnDamageText(dmg);

            if (health <= 0f)
            {
                game_over_channel.RaiseEvent();
                gameObject.SetActive(false);
            }
        }

        private void SpawnDamageText(int dmg_value)
        {
            Vector3 offset = new Vector3(0f, 1.5f, 0f);
            GameObject text_popup = Instantiate(damage_text, transform.position + offset, transform.rotation);
            string text = "-" + dmg_value.ToString();
            text_popup.GetComponent<FloatingTextDisplay>().SetText(text, Color.red);
        }
    }
}

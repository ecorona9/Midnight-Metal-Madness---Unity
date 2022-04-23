/* SUMMARY:
 * HealingUnit heals the player on pickup. Attach this script to HealingUnit prefabs
 */
using UnityEngine;

namespace MidnightMetalMadness.Entity.Interactables
{
    public class HealingUnit : MonoBehaviour, IHealthChange
    {
        [SerializeField] private int amount;

        private bool has_collided = false;

        private void OnCollisionEnter2D()
        {
            gameObject.SetActive(false);
            has_collided = true;
        }
        
        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        private void OnBecameVisible()
        {
            if (!has_collided)
            {
                gameObject.SetActive(true);
            }
        }

        public int HealthChangeAmount() => amount;
    }
}

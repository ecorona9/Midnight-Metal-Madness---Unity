/* SUMMARY:
 * BullXProjectile logic. Attach this script to BULL-X prefabs
 */
using UnityEngine;

namespace MidnightMetalMadness.Entity.Weapons
{
    public class BullXProjectile : MonoBehaviour, IHealthChange, IProjectiles
    {
        [SerializeField] private int damage;
        [SerializeField] private GameObject hitbox;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Fire(bool is_facing_right, Vector3 muzzle)
        {
            AudioManager.instance.PlayBullX();
            if (is_facing_right)
            {
                transform.SetPositionAndRotation(muzzle, Quaternion.identity);
            } 
            else
            {
                transform.SetPositionAndRotation(muzzle, Quaternion.Euler(0f, 180f, 0f));
            }
            animator?.SetTrigger("BullxFire");
            hitbox?.SetActive(true);
        }

        public int HealthChangeAmount() => damage;

        // Called by animation event
        public void TurnOffHitbox()
        {
            if (hitbox != null) return;

            if (hitbox.activeSelf) hitbox.SetActive(false);
        }

        private void OnCollisionEnter2D()
        {
            gameObject.SetActive(false);
        }

        // Destroy the bullet when it has left the camera's vision
        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }
    }
}

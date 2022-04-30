/* SUMMARY:
 * AR75Projectile logic. Attach this script to AR75 prefabs
 */
using UnityEngine;

namespace MidnightMetalMadness.Entity.Weapons
{
    public class AR75Projectile : MonoBehaviour, IHealthChange, IProjectiles
    {
        [SerializeField] private int damage;
        [SerializeField] private float speed;

        // Fire the bullet towards the right or left given the direction and speed
        public void Fire(bool is_facing_right, Vector3 muzzle)
        {
            AudioManager.instance.PlayAR75();
            if (is_facing_right)
            {
                transform.SetPositionAndRotation(muzzle, Quaternion.identity);
            }
            else
            {
                transform.SetPositionAndRotation(muzzle, Quaternion.Euler(0f, 180f, 0f));
            }
        }

        private void Update()
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }

        public int HealthChangeAmount() => damage;

        private void OnTriggerEnter2D()
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

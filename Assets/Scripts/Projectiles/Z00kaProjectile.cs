/* SUMMARY:
 * Z00kaProjectile logic. Attach this script to Z00-KA prefabs
 */
using UnityEngine;

namespace MidnightMetalMadness.Entity.Weapons
{
    public class Z00kaProjectile : MonoBehaviour, IHealthChange, IProjectiles
    {
        [SerializeField] private int damage;
        [SerializeField] private float speed;

        public void Fire(bool is_facing_right, Vector3 muzzle)
        {
            AudioManager.instance.PlayZ00ka();
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

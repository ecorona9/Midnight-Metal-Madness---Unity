/* SUMMARY:
 * Z00kaProjectile logic. Attach this script to Z00-KA prefabs
 */
using UnityEngine;

namespace MidnightMetalMadness
{
    public class Z00kaProjectile : MonoBehaviour, IHealthChange, IProjectiles
    {
        [SerializeField] private int damage;
        [SerializeField] private float speed;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Fire(bool is_facing_right, Vector3 muzzle)
        {
            AudioManager.instance.PlayZ00ka();
            if (is_facing_right)
            {
                transform.SetPositionAndRotation(muzzle, Quaternion.identity);
                rb.velocity = new Vector2(speed, 0f);
            }
            else
            {
                transform.SetPositionAndRotation(muzzle, Quaternion.Euler(0f, 180f, 0f));
                rb.velocity = new Vector2(-1 * speed, 0f);
            }
        }

        public int HealthChangeAmount() => damage;

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

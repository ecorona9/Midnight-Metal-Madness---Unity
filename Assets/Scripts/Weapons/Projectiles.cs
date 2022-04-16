using UnityEngine;

namespace MidnightMetalMadness.Entity.Weapons
{
    public class Projectiles : MonoBehaviour, IHealthChange
    {
        [SerializeField] private int damage;

        private Rigidbody2D projectile_rigidbody;

        private void Awake()
        {
            projectile_rigidbody = GetComponent<Rigidbody2D>();
        }

        // Fire the bullet towards the right or left given the direction and speed
        public void Fire(bool is_facing_right, float speed, int damage)
        {
            this.damage = damage;
            if (is_facing_right)
            {
                projectile_rigidbody.velocity = new Vector2(speed, 0f);
            }
            else
            {
                projectile_rigidbody.velocity = new Vector2(-1 * speed, 0f);
            }
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

        public int HealthChangeAmount()
        {
            return damage;
        }
    }
}
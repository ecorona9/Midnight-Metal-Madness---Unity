// SUMMARY:
// EnemyHealth manages the health of the enemy
//
using System.Collections;
using UnityEngine;

namespace MidnightMetalMadness.Entity
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private Enemy enemy_type;

        [SerializeField] private GameObject explosion;

        [SerializeField] private VoidEventSO score_channel;

        private Animator animator;
        private SpriteRenderer sprite;
        private WaitForSeconds timer;
        private BoxCollider2D hitbox;

        private Color default_color;
        private Color hurt_color;

        private float health;
        private bool can_take_damage;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            hitbox = GetComponent<BoxCollider2D>();
            sprite = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            timer = new WaitForSeconds(0.05f);
            default_color = new Color(255f, 255f, 255f, 255f);
            hurt_color = new Color(255f, 255f, 255f, 0f);
            health = enemy_type.health;
            can_take_damage = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Health Changer"))
            {
                if (can_take_damage)
                {
                    can_take_damage = hitbox.enabled = false;
                    health += collision.gameObject.GetComponent<IHealthChange>().HealthChangeAmount();

                    if (health <= 0f)
                    {
                        animator.SetTrigger("Explode2");
                    }
                    StartCoroutine(BlinkEffect());
                }
            }
        }

        private IEnumerator BlinkEffect()
        {
            int iterations = 0;
            while (iterations < 4)
            {
                sprite.color = hurt_color;
                yield return timer;
                sprite.color = default_color;
                yield return timer;
                iterations++;
            }
            can_take_damage = hitbox.enabled = true;
        }

        public void PlayExplosion()
        {
            AudioManager.instance.PlayExplosion();
            Instantiate(explosion, transform.position, Quaternion.identity);
            score_channel.RaiseEvent();
        }

        public void DestroyObject()
        {
            Destroy(gameObject);
        }

        public void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        private void OnBecameVisible()
        {
            gameObject.SetActive(true);   
        }
    }
}

using MidnightMetalMadness.Entity.Weapons;
using UnityEngine;

namespace MidnightMetalMadness.Entity
{
    public class CopController : MonoBehaviour
    {
        [SerializeField] private Enemy enemy_type;

        [SerializeField] private int id;

        [SerializeField] private float distance;

        [SerializeField] private Transform muzzle;

        private Animator animator;
        private Vector3 event_pos;

        private float ypos;
        private bool is_event_triggered;
        private bool is_firing;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            ypos = transform.position.y;
            is_event_triggered = false;
            EventAreaManager.instance.OnPlayerEntersArea += Move;
        }

        private void Update()
        {
            if (is_event_triggered)
            {
                animator.SetBool("CopMove", true);
                var step = enemy_type.speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, ypos), 
                                                        new Vector2(event_pos.x, ypos), step);

                if (Vector2.Distance(new Vector2(transform.position.x, ypos), new Vector2(event_pos.x, ypos)) < 0.001f)
                {
                    is_event_triggered = false;
                    is_firing = true;
                }
            }

            if (is_firing)
            {
                animator.SetBool("CopMove", false);
                animator.SetBool("CopShoot", true);
            }
        }

        private void Move(Transform player, int id)
        {
            if (this.id != id) return;

            event_pos = player.position + new Vector3(distance, 0f, 0f);
            is_event_triggered = true;

        }

        private void OnDestroy()
        {
            EventAreaManager.instance.OnPlayerEntersArea -= Move;
        }

        public void FireProjectile()
        {
            GameObject pooled_projectile = PoolManager.pool_instance.GetPooledProjectile(5);
            pooled_projectile.SetActive(true);
            var bullet = pooled_projectile.GetComponent<IProjectiles>();
            bullet.Fire(false, muzzle.position);
        }



    }
}

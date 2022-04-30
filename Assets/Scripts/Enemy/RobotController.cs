// SUMMARY:
// RobotController is a type of enemy ai
// SUMMARY:
// RobotController handles the movement for the enemy typed Robot
//
using UnityEngine;

namespace MidnightMetalMadness.Entity
{
    public class RobotController : MonoBehaviour
    {
        [SerializeField] private Enemy enemy_type;

        private Animator animator;

        private Vector3 right;
        private Vector3 left;

        private Transform player;

        private float ypos;
        private float player_ypos;

        private bool is_idle;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            left = new Vector3(0f, 0f, 0f);
            right = new Vector3(0f, 180f, 0f);
            is_idle = true;
        }

        private void Update()
        {
            if (player == null) return;

            if (Vector2.Distance(player.position, transform.position) < 3f)
            {
                is_idle = false;
                ypos = transform.position.y;
                player_ypos = transform.position.y;
                animator.SetTrigger("Angry");
            }

            if (!is_idle)
            {
                SetFacingDirection();

                animator.SetFloat("Explode", Vector2.Distance(player.position, transform.position));
                var step = enemy_type.speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, ypos), 
                                                        new Vector3(player.position.x, player_ypos), step);        
            }
        }

        private void SetFacingDirection()
        {
            if (player.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(left);
            }
            else if (player.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(right);
            }
        }

        public void GetPlayerTransform(Transform player)
        {
            this.player = player;
        }
    }
}

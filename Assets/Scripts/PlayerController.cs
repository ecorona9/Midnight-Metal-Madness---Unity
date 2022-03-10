using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player_rigidbody;
    private Vector2 motion_vector;
    private Animator player_animator;

    [Header("Player Stats")]
    [SerializeField] private PlayerStats player_stats;

    [Header("Ground Check")]
    [SerializeField] private Transform ground_check_point;
    [SerializeField] private LayerMask ground_mask;
    private bool is_grounded;

    [Header("Projectile Weapon")]
    [SerializeField] private Transform muzzle_point;

    // Movement
    private float xraw;
    private bool is_facing_right;

    // Shooting
    private float shoot_cooldown;

    private void Awake()
    {
        player_rigidbody = GetComponent<Rigidbody2D>();
        player_animator = GetComponent<Animator>();
    }

    private void Start()
    {
        is_facing_right = true;
    }

    private void Update()
    {
        if (Time.timeScale != 0f)
        {
            // Horizontal Input
            xraw = Input.GetAxisRaw("Horizontal");
            motion_vector = new Vector2(xraw, 0f);

            // Flip model
            Vector3 scale = transform.localScale;
            if (xraw < 0)
            {
                scale.x = -1;
                is_facing_right = false;
            }
            if (xraw > 0)
            {
                scale.x = 1;
                is_facing_right = true;
            }
            transform.localScale = scale;

            // Jump Input
            if (Input.GetKeyDown(KeyCode.Space) && is_grounded)
            {
                Jump();
            }

            // Shooting Projectiles Input
            if (Input.GetKeyDown(KeyCode.J) && Time.time > shoot_cooldown)
            {
                shoot_cooldown = Time.time + player_stats.fire_rate;
                Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        if (Time.timeScale != 0f)
        {
            // Ground Check
            is_grounded = Physics2D.OverlapCircle(ground_check_point.position, 1f, ground_mask);

            // Horizontal Movement
            player_rigidbody.velocity = new Vector2(motion_vector.x * player_stats.horizontal_speed * Time.deltaTime, player_rigidbody.velocity.y);
        }
    }

    // Apply an instaneous force upward on the player
    private void Jump()
    {
        //player_animator.SetTrigger("Jump");
        player_rigidbody.AddForce(Vector2.up * player_stats.jump_force, ForceMode2D.Impulse);
    }

    // Shoots a bullet object from the muzzle point
    private void Shoot()
    {
        GameObject bullet_obj = Instantiate(player_stats.projectile, muzzle_point.position, muzzle_point.rotation);
        bullet_obj.GetComponent<Projectiles>().Fire(is_facing_right);
    }

}

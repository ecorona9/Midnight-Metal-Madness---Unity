using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player_rigidbody;
    private Animator player_animator;

    [Header("Player Stats")]
    [SerializeField] private PlayerStats player_stats;

    [Header("Player Sprite")]
    [SerializeField] private Transform player_sprite;

    [Header("Ground Check")]
    [SerializeField] private Transform ground_check_point;
    [SerializeField] private LayerMask ground_mask; 
    [SerializeField] private PhysicsMaterial2D no_friction;
    [SerializeField] private PhysicsMaterial2D full_friction;
    [SerializeField] private float slope_check_distance;
    [SerializeField] private float ground_check_radius;
    [SerializeField] private float max_slope_angle;

    // Movement
    private Vector2 slope_norm_perp;

    private float xraw;
    private float downward_slope_angle;
    private float downward_slope_angle_old;
    private float side_slope_angle;

    private bool is_facing_right;
    private bool can_jump;
    private bool is_jumping;
    private bool is_on_slope;
    private bool is_grounded;
    private bool can_walk_on_slope;



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
        if (Time.timeScale != 0f && !GameStateManager.instance.IsGameOver())
        {
            // Horizontal Input
            xraw = Input.GetAxisRaw("Horizontal");

            // Flip model
            if (xraw < 0 && is_facing_right)
            {
                FlipCharacter();
            }
            if (xraw > 0 && !is_facing_right)
            {
                FlipCharacter();
            }
            // Jump Input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(is_on_slope);
        if (Time.timeScale != 0f && !GameStateManager.instance.IsGameOver())
        {
            // Ground Check
            is_grounded = Physics2D.OverlapCircle(ground_check_point.position, ground_check_radius, ground_mask);    

            if(player_rigidbody.velocity.y <= 0.0f)
            {
                is_jumping = false;
            }

            if (is_grounded && !is_jumping && downward_slope_angle <= max_slope_angle) 
            {
                can_jump = true;
            }

            CheckSlope();

            // Movement
            if (is_grounded && !is_on_slope && !is_jumping)
            {
                player_rigidbody.velocity = new Vector2(xraw * player_stats.horizontal_speed, 0.0f);
            }
            else if (is_grounded && is_on_slope && !is_jumping && can_walk_on_slope)
            {
                float x = -xraw * slope_norm_perp.x * player_stats.horizontal_speed;
                float y = -xraw * slope_norm_perp.y * player_stats.horizontal_speed;

                player_rigidbody.velocity = new Vector2(x, y);
            }
            else if (!is_grounded)
            {
                player_rigidbody.velocity = new Vector2(xraw * player_stats.horizontal_speed, player_rigidbody.velocity.y);
            }
        }
    }

    // check the angle of the slope we are on
    private void CheckSlope()
    {
        Vector2 origin = new Vector2(ground_check_point.position.x, ground_check_point.position.y);

        CheckSlopeHorizontal(origin);
        CheckSlopeVertical(origin);
    }

    // Calculating the x component of the normal vectors
    private void CheckSlopeHorizontal(Vector2 origin)
    {
        RaycastHit2D ray_hit_front = Physics2D.Raycast(origin, transform.right, slope_check_distance, ground_mask);
        RaycastHit2D ray_hit_back = Physics2D.Raycast(origin, -transform.right, slope_check_distance, ground_mask);

        if (ray_hit_front)
        {
            is_on_slope = true;
            side_slope_angle = Vector2.Angle(ray_hit_front.normal, Vector2.up);
        }
        else if (ray_hit_back)
        {
            is_on_slope = true;
            side_slope_angle = Vector2.Angle(ray_hit_back.normal, Vector2.up);
        }
        else
        {          
            side_slope_angle = 0.0f;
            is_on_slope = false;
        }
    }

    // Calculating the y component of the normal vectors
    private void CheckSlopeVertical(Vector2 origin)
    {
        RaycastHit2D ray_hit = Physics2D.Raycast(origin, Vector2.down, slope_check_distance, ground_mask);

        if (ray_hit)
        {
            slope_norm_perp = Vector2.Perpendicular(ray_hit.normal).normalized;

            downward_slope_angle = Vector2.Angle(ray_hit.normal, Vector2.up);

            if (downward_slope_angle != downward_slope_angle_old)
            {
                is_on_slope = true;
            }

            downward_slope_angle_old = downward_slope_angle;

            Debug.DrawRay(ray_hit.point, slope_norm_perp, Color.red);
            Debug.DrawRay(ray_hit.point, ray_hit.normal, Color.red);
        }

        if (downward_slope_angle > max_slope_angle || side_slope_angle > max_slope_angle)
        {
            can_walk_on_slope = false;
        }
        else
        {
            can_walk_on_slope = true;
        }

        if (is_on_slope && xraw == 0 && can_walk_on_slope)
        {
            player_rigidbody.sharedMaterial = full_friction;
        }
        else
        {
            player_rigidbody.sharedMaterial = no_friction;
        }
    }

    private void FlipCharacter()
    {
        Vector3 current_scale = player_sprite.transform.localScale;
        current_scale.x *= -1;
        player_sprite.transform.localScale = current_scale;
        is_facing_right = !is_facing_right;
    }

    private void Jump()
    {
        //player_animator.SetTrigger("Jump");
        if (can_jump)
        {
            can_jump = false;
            is_jumping = true;
            player_rigidbody.AddForce(Vector2.up * player_stats.jump_force, ForceMode2D.Impulse);
        }
    }

    public bool IsFacingRight()
    {
        return is_facing_right;
    }
}

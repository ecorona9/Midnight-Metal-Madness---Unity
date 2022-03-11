using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player_rigidbody;
    private Animator player_animator;

    [Header("Player Stats")]
    [SerializeField] private PlayerStats player_stats;

    [Header("Ground Check")]
    [SerializeField] private Transform ground_check_point;
    [SerializeField] private LayerMask ground_mask;
    private bool is_grounded;


    // Movement
    private Vector2 motion_vector;
    private float xraw;
    private bool is_facing_right;


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

            if (xraw < 0 && is_facing_right)
            {
                FlipCharacter();
            }
            if (xraw > 0 && !is_facing_right)
            {
                FlipCharacter();
            }


            // Jump Input
            if (Input.GetKeyDown(KeyCode.Space) && is_grounded)
            {
                Jump();
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

    private void FlipCharacter()
    {
        Vector3 current_scale = transform.localScale;
        current_scale.x *= -1;
        transform.localScale = current_scale;
        is_facing_right = !is_facing_right;
    }

    // Apply an instaneous force upward on the player
    private void Jump()
    {
        //player_animator.SetTrigger("Jump");
        player_rigidbody.AddForce(Vector2.up * player_stats.jump_force, ForceMode2D.Impulse);
    }

    public bool IsFacingRight()
    {
        return is_facing_right;
    }

}

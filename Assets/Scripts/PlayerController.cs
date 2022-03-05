using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player_rigidbody;
    private Vector2 motion_vector;

    [Header("Movement")]
    [SerializeField] private float horizontal_speed;
    [SerializeField] private float jump_force;
    private float xraw;
    private bool is_facing_right;

    [Header("Ground Check")]
    [SerializeField] private Transform ground_check_point;
    [SerializeField] private LayerMask ground_mask;
    private bool is_grounded;

    [Header("Projectile Weapon")]
    [SerializeField] private Transform muzzle_point;
    [SerializeField] private GameObject bullet;

    private void Awake()
    {
        player_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        is_facing_right = true;
    }

    private void Update()
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
        if (Input.GetKeyDown(KeyCode.J))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        // Ground Check
        is_grounded = Physics2D.OverlapCircle(ground_check_point.position, 1f, ground_mask);

        // Horizontal Movement
        player_rigidbody.velocity = new Vector2(motion_vector.x * horizontal_speed * Time.deltaTime, player_rigidbody.velocity.y);
    }

    // Apply an instaneous force upward on the player
    private void Jump()
    {
        player_rigidbody.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);
    }

    // Shoots a bullet object from the muzzle point
    private void Shoot()
    {
        GameObject bullet_obj = Instantiate(bullet);
        bullet_obj.transform.position = new Vector3(muzzle_point.position.x, transform.position.y);
        bullet_obj.GetComponent<Projectiles>().Fire(is_facing_right);
    }

}

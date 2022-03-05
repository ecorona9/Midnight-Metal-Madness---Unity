using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D projectile_rigidbody;

    private void Awake()
    {
        projectile_rigidbody = GetComponent<Rigidbody2D>();
    }
    
    // Fire the bullet towards the right or left given the direction
    public void Fire(bool is_facing_right)
    {
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
        Destroy(gameObject);
    }

    // Destroy the bullet when it has left the camera's vision
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}

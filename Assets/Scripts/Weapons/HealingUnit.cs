using UnityEngine;

public class HealingUnit : MonoBehaviour
{
    public int healing;
    private Rigidbody2D projectile_rigidbody;
    private void Awake()
    {
        projectile_rigidbody = GetComponent<Rigidbody2D>();
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
}

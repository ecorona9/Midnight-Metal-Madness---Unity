/* Summary:
 * 
 * This script manages the health points of the player
 * 
 */
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerStats player_stats;

    private int health;
    
    private void Awake()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(5);
        }
    }

    private void Start()
    {
        health = player_stats.maximum_health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectiles"))
        {
            int dmg = collision.gameObject.GetComponent<Projectiles>().damage;
            TakeDamage(dmg);
        }
    }

    public void TakeDamage(int dmg)
    {
        EventManager.instance.DecreasePlayerHealthInUI(dmg);
        health -= dmg;
        if (health <= 0f)
        {
            EventManager.instance.LoseGame();
            gameObject.SetActive(false);
        }
    }




}

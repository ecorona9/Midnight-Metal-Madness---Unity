/* Summary:
 * 
 * This script manages the health points of the player
 * 
 */
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerStats player_stats;

    [SerializeField] private GameObject damage_text;

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

        if (collision.gameObject.CompareTag("HealingUnit"))
        {
            int dmg = collision.gameObject.GetComponent<HealingUnit>().healing;
            TakeDamage(-dmg);
        }
    }

    public void TakeDamage(int dmg)
    {
        EventManager.instance.DisplayPlayerHealth(dmg);
        health -= dmg;
        Vector3 offset = new Vector3(0f, 1.5f, 0f);
        GameObject text_popup = Instantiate(damage_text, transform.position + offset, transform.rotation);
        string text = "-" + dmg.ToString();
        text_popup.GetComponent<FloatingTextDisplay>().SetText(text, Color.red);

        if (health <= 0f)
        {
            EventManager.instance.LoseGame();
            gameObject.SetActive(false);
        }
    }




}

/*
 * Summary:
 * 
 * HealthBar updates the player's health in the UI
 * 
 * 
 */
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerStats player_stats;
    private Image hp_slider;
    private float maximum_health;
    private int current_health;
    private void Awake()
    {
        hp_slider = GetComponent<Image>();
    }
    private void Start()
    {
        current_health = player_stats.maximum_health;
        maximum_health = player_stats.maximum_health;
        hp_slider.fillAmount = current_health / maximum_health;
        EventManager.instance.OnPlayerTakesDamage += DecreaseHealth;
    }
    public void DecreaseHealth(int dmg)
    {
        current_health -= dmg;
        hp_slider.fillAmount = current_health / maximum_health;
    }
    private void OnDestroy()
    {
        EventManager.instance.OnPlayerTakesDamage -= DecreaseHealth;
    }
}

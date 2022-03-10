/*  File Description:
 *  PlayerStats contains stats of the player
*/
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerStats", menuName = "Game Settings/Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Player Variables")]
    public float horizontal_speed;
    public float jump_force;

    [Header("Projectile Weapon Variables")]
    public float fire_rate;
    public GameObject projectile;
    public float projectile_speed;

}

/*  File Description:
 *  PlayerStats contains stats of the player
*/
using UnityEngine;

namespace MidnightMetalMadness
{
    [CreateAssetMenu(fileName = "New PlayerStats", menuName = "Game Settings/Player Stats")]
    public class PlayerStats : ScriptableObject
    {
        [Header("Player Variables")]
        public int maximum_health;
        public float horizontal_speed;
        public float jump_force;
    }
}

using UnityEngine;

/* CLASS DESCRIPTION:
 * MeleeWeapon class contains the damage info of the weapon,
 * the weapon's sprite image, the size of the hitbox, and the attack speed
 */
namespace MidnightMetalMadness.Entity.Weapons
{
    [CreateAssetMenu(fileName = "New MeleeWeapon", menuName = "Items/Weapons/Melee Weapon")]
    public class MeleeWeapon : ScriptableObject
    {
        public int damage;

        public Sprite weapon_sprite;

        public Vector2 hitbox_dimensions;

        public float attack_speed;
    }
}

using UnityEngine;

namespace MidnightMetalMadness.Entity.Weapons
{
    public enum PoolWeaponIndex
    {
        k_pistol = 0,
        k_assault_rile = 1,
        k_shotgun = 2,
        k_sniper = 3,
        k_launcher = 4,
        k_enemy_gun = 5,
    }

    [CreateAssetMenu(fileName = "New ProjectileWeapon", menuName = "Items/Weapons/Projectile Weapon")]
    public class ProjectileWeapon : ScriptableObject
    {
        public PoolWeaponIndex weapon_type;

        public int damage;

        public Sprite weapon_sprite;

        [Header("Fire Rate")]
        public float shoot_cooldown;

        [Header("The local position of the weapon object")]
        public Vector3 weapon_position;

        [Header("The local position of the muzzle object")]
        public Vector3 muzzle_position;

        public int ammo_count;

        public float proj_speed;

    }
}

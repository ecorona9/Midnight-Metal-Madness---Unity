using UnityEngine;

namespace MidnightMetalMadness
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

    [CreateAssetMenu(menuName = "Weapon/Projectile Wepaon")]
    public class ProjectileWeapon : ScriptableObject
    {
        public PoolWeaponIndex weapon_type;
        public Sprite weapon_sprite;
        public int damage;       
        public int ammo_count;
        
        [Header("Fire Rate")]
        public float shoot_cooldown;
        public float proj_speed;

        [Header("The local position of the weapon object")]
        public Vector3 weapon_position;
        [Header("The local position of the muzzle object")]
        public Vector3 muzzle_position;
    }
}

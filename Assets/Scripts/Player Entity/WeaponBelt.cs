/* Summary:
 * WeaponBelt manages what projectile weapon the player is carrying 
 */
using UnityEngine;
using MidnightMetalMadness.Entity.Weapons;

namespace MidnightMetalMadness.Entity.Player
{
    public class WeaponBelt : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] private IntEventSO current_ammo_channel;
        [SerializeField] private IntEventSO maximum_ammo_channel;
        [SerializeField] private SpriteEventSO sprite_change_channel;
        
        [Header("Transform of Projectile Weapon")]
        [SerializeField] private Transform proj_weapon;
        [SerializeField] private Transform muzzle;

        [Header("Default Weapon")]
        [SerializeField] private ProjectileWeapon default_weapon;

        private PlayerController player_controller;
        private SpriteRenderer proj_weapon_sprite;
        private Animator proj_weapon_animator;      
        private ProjectileWeapon current_weapon;
        private int current_ammo_count;
        private float shoot_cooldown;

        private void Awake()
        {
            player_controller = GetComponent<PlayerController>();
            proj_weapon_sprite = proj_weapon.GetComponent<SpriteRenderer>();
            proj_weapon_animator = GetComponent<Animator>();
        }

        private void Start()
        {
            SwapWeapon(default_weapon);
            shoot_cooldown = 0f;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J) && Time.time > shoot_cooldown)
            {
                if (current_ammo_count > 0 || current_weapon == default_weapon)
                {
                    shoot_cooldown = Time.time + current_weapon.shoot_cooldown;
                    Shoot();
                }
            }

            if (current_ammo_count <= 0 && current_weapon != default_weapon)
            {
                SwapWeapon(default_weapon);
            }
        }

        // Accessed by CarePackge objects
        public void ChangeToCarePackageWeapon(ProjectileWeapon obj)
        {
            if (IsDuplicateWeapon(obj))
            {
                current_ammo_count = current_weapon.ammo_count;
                current_ammo_channel.RaiseEvent(current_ammo_count);
            }
            else
            {
                SwapWeapon(obj);
            }

        }

        private void SwapWeapon(ProjectileWeapon obj)
        {
            current_weapon = obj;
            current_ammo_count = obj.ammo_count;
            muzzle.localPosition = obj.muzzle_position;
            proj_weapon.localPosition = obj.weapon_position;
            proj_weapon_sprite.sprite = obj.weapon_sprite;

            maximum_ammo_channel.RaiseEvent(obj.ammo_count);
            current_ammo_channel.RaiseEvent(obj.ammo_count);
            sprite_change_channel.RaiseEvent(current_weapon.weapon_sprite);
        }

        private bool IsDuplicateWeapon(ProjectileWeapon obj)
        {
            if (current_weapon == obj)
            {
                return true;
            }
            return false;
        }

        private void Shoot()
        {
            GameObject pooled_projectile = PoolManager.pool_instance.GetPooledProjectile((int)current_weapon.weapon_type);
            pooled_projectile.SetActive(true);
            var bullet = pooled_projectile.GetComponent<IProjectiles>();

            bullet.Fire(player_controller.IsFacingRight, muzzle.position);

            if (current_weapon != default_weapon)
            {
                current_ammo_count--;
                current_ammo_channel.RaiseEvent(current_ammo_count);
            }
        }
    }
}

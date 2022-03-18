using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBelt : MonoBehaviour
{
    private PlayerController player_controller;
    private SpriteRenderer proj_weapon_sprite;
    private Animator proj_weapon_animator;

    [Header("Transform of Projectile Weapon")]
    [SerializeField] private Transform proj_weapon;
    [SerializeField] private Transform muzzle;

    [Header("Default Weapon")]
    [SerializeField] private ProjectileWeapon default_weapon;

    private ProjectileWeapon current_weapon;

    private int current_ammo_count;

    // Basically fire rate, but this is the least amount of time between each click
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && Time.time > shoot_cooldown && current_ammo_count > 0)
        {
            shoot_cooldown = Time.time + current_weapon.shoot_cooldown;
            Shoot();
        }

        if (current_ammo_count <= 0)
        {
            SwapWeapon(default_weapon);
        }
    }

    public void ChangeToCarePackageWeapon(ProjectileWeapon obj)
    {
        // Refill ammo
        if (IsDupe(obj))
        {
            current_ammo_count = current_weapon.ammo_count;    
        }
        // Update current weapon as well as the position of the gun sprite
        else
        {
            SwapWeapon(obj);
        }

    }

    public void SwapWeapon(ProjectileWeapon obj)
    {
        current_weapon = obj;
        current_ammo_count = obj.ammo_count;
        muzzle.localPosition = obj.muzzle_position;
        proj_weapon.localPosition = obj.weapon_position;
        proj_weapon_sprite.sprite = obj.weapon_sprite;
        // TODO: Swap Animation Controllers
    }

    // Returns true if the care package weapon picked up is the same as our current weapon
    private bool IsDupe(ProjectileWeapon obj)
    {
        if (current_weapon == obj)
        {
            return true;
        }
        return false;
    }

    private void Shoot()
    {
        GameObject bullet_obj = Instantiate(current_weapon.projectile, muzzle.position, Quaternion.identity);
        bullet_obj.GetComponent<Projectiles>().damage = current_weapon.damage;
        bullet_obj.GetComponent<Projectiles>().Fire(player_controller.IsFacingRight(), current_weapon.proj_speed);

        if (current_weapon == default_weapon)
        {
            // TODO: Play gun sound here
        }
        else
        {
            current_ammo_count--;
        }
    }
}

using UnityEngine;

public enum ProjectileWeaponType { Pistol, AssaultRifle, Shotgun, Sniper, Launcher}

[CreateAssetMenu(fileName = "New ProjectileWeapon", menuName = "Items/Weapons/Projectile Weapon")]
public class ProjectileWeapon : ScriptableObject
{
    public ProjectileWeaponType type;

    public int damage;

    public Sprite weapon_sprite;

    [Header("Fire Rate")]
    public float shoot_cooldown;

    public Vector3 weapon_position;

    public Vector3 muzzle_position;

    public GameObject projectile;

    public int ammo_count;

    public float proj_speed;

}

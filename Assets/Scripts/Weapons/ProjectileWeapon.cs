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

    [Header("The local position of the weapon object")]
    public Vector3 weapon_position;

    [Header("The local position of the muzzle object")]
    public Vector3 muzzle_position;

    [Header("The projectile that is being fired")]
    public GameObject projectile;

    public int ammo_count;

    public float proj_speed;

}

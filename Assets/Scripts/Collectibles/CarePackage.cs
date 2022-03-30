// SUMMARY:
// 
// Requires a collider2d component and the gameobject layer to be "Trigger"
//
using UnityEngine;
using MidnightMetalMadness.Entity.Weapons;
using MidnightMetalMadness.Entity.Player;

namespace MidnightMetalMadness.Entity.Collectibles
{
    public class CarePackage : MonoBehaviour
    {
        [SerializeField] private ProjectileWeapon weapon;

        private void OnTriggerEnter2D(Collider2D other)
        { 
            other.gameObject?.GetComponent<WeaponBelt>().ChangeToCarePackageWeapon(weapon);
            Destroy(transform.parent.gameObject);
        }
    }
}

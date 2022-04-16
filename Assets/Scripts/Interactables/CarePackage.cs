// SUMMARY:
// 
// Requires a collider2d component and the gameobject layer to be "Trigger"
//
using UnityEngine;
using MidnightMetalMadness.Entity.Player;

namespace MidnightMetalMadness.Entity.Interactables
{
    public class CarePackage : MonoBehaviour
    {
        [SerializeField] private ProjectileWeapon weapon;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other == null) return;

            other.gameObject?.GetComponent<WeaponBelt>().ChangeToCarePackageWeapon(weapon);
            Destroy(transform.parent.gameObject);
        }
    }
}

using UnityEngine;

public class CarePackage : MonoBehaviour
{
    [SerializeField] private ProjectileWeapon weapon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<WeaponBelt>().ChangeToCarePackageWeapon(weapon);
        Destroy(transform.parent.gameObject);
    }
}

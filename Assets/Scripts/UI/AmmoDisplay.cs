/*
 * Summary:
 * 
 * AmmoDisplay will display the current ammo the player has on the Gameplay canvas
 * 
 */
using UnityEngine;
using UnityEngine.UI;

namespace MidnightMetalMadness.UI
{
    public class AmmoDisplay : MonoBehaviour
    {
        [SerializeField] private Text current_ammo;
        [SerializeField] private Text maximum_ammo;
        [SerializeField] private Image current_weapon;

        private Animator current_ammo_animator;

        private void Start()
        {
            EventManager.instance.OnPlayerShoot += SetCurrentAmmo;
            EventManager.instance.OnPlayerSwapWeapon += SetMaximumAmmo;
            current_ammo_animator = current_ammo.gameObject.GetComponent<Animator>();
        }

        private void SetCurrentAmmo(int value)
        {
            if (value == -1)
            {
                current_ammo.text = "\u221E";   // infinity in unicode
            }
            else
            {
                current_ammo.text = value.ToString();
                current_ammo_animator.SetTrigger("AmmoChange");
            }
        }

        private void SetMaximumAmmo(int value, Sprite image)
        {
            if (value == -1)
            {
                maximum_ammo.text = "/  " + "\u221E";   // infinity in unicode
            }
            else
            {
                maximum_ammo.text = "/  " + value.ToString();
            }
            current_weapon.sprite = image;
        }

        private void OnDestroy()
        {
            EventManager.instance.OnPlayerShoot -= SetCurrentAmmo;
            EventManager.instance.OnPlayerSwapWeapon -= SetMaximumAmmo;
        }
    }
}

// SUMMARY:
// Attach to child object of bullx projectile

using UnityEngine;

namespace MidnightMetalMadness
{
    public class BullXAnimation : MonoBehaviour
    {
        private void DisableProjectileOnAnimationEnd()
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}

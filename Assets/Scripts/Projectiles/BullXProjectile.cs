/* SUMMARY:
 * BullXProjectile logic. Attach this script to BULL-X prefabs
 */
using System.Collections;
using UnityEngine;

namespace MidnightMetalMadness.Entity.Weapons
{
    public class BullXProjectile : MonoBehaviour, IHealthChange, IProjectiles
    {
        [SerializeField] private int damage;

        [SerializeField] private Animator animator;

        [SerializeField] private float speed;

        [SerializeField] private float flight_time;

        private WaitForSeconds timer;

        private void Start()
        {
            timer = new WaitForSeconds(flight_time);
        }

        public void Fire(bool is_facing_right, Vector3 muzzle)
        {
            AudioManager.instance.PlayBullX();
            if (is_facing_right)
            {
                transform.SetPositionAndRotation(muzzle, Quaternion.identity);
            }
            else
            {
                transform.SetPositionAndRotation(muzzle, Quaternion.Euler(0f, 180f, 0f));
            }
            animator?.SetTrigger("BullxFire");
        }

        private void Update()
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
            StartCoroutine(DisableObject());
        }

        private IEnumerator DisableObject()
        {
            yield return timer;
            gameObject.SetActive(false);
        }

        public int HealthChangeAmount() => damage;

        private void OnTriggerEnter2D()
        {
            gameObject.SetActive(false);
        }

        // Destroy the bullet when it has left the camera's vision
        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }
    }
}

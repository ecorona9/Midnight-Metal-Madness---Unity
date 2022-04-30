using UnityEngine;

namespace MidnightMetalMadness.Entity
{
    public class Explosion : MonoBehaviour, IHealthChange
    {
        private int damage;

        private void Start()
        {
            damage = -20;

            Destroy(gameObject, 1f);
        }

        public int HealthChangeAmount() => damage;

    }
}

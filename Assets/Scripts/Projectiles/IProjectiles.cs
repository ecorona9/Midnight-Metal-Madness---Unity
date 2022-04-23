/* Summary:
 * All bullet types implement IProjectiles interface
 */
using UnityEngine;

namespace MidnightMetalMadness.Entity.Weapons
{
    public interface IProjectiles
    {
        public void Fire(bool is_facing_right, Vector3 muzzle);
    }
}

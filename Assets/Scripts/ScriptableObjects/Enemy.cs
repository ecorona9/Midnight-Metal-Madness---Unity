// SUMMARY:
// Enemy class has a speed var and a health var
//
using UnityEngine;

namespace MidnightMetalMadness
{
    [CreateAssetMenu(menuName = "Enemy")]
    public class Enemy : ScriptableObject
    {
        public float speed;
        public int health;
    }
}
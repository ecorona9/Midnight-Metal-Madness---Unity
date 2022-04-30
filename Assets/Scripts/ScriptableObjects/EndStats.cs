using UnityEngine;

namespace MidnightMetalMadness
{
    [CreateAssetMenu(menuName = "EndStat")]
    public class EndStats : ScriptableObject
    {
        [HideInInspector] public int score = 0;
    }
}

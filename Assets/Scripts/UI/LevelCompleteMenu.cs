using TMPro;
using UnityEngine;

namespace MidnightMetalMadness
{
    public class LevelCompleteMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI end_score;

        [SerializeField] private EndStats end_stats;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void ShowLevelCompleteMenu()
        {
            animator.SetTrigger("Show Level Complete");
            end_score.text = "Score: " + end_stats.score.ToString();
        }

        public void HideLevelCompleteMenu()
        {
            animator.SetTrigger("Hide Level Complete");
        }
    }
}

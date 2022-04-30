using TMPro;
using UnityEngine;

namespace MidnightMetalMadness.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private EndStats final;

        private TextMeshProUGUI text;

        private int score;

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            score = 0;
            final.score = score;
            UpdateScoreDisplay();
        }

        public void IncreaseScore()
        {
            score += 100;
            final.score = score;
            UpdateScoreDisplay();
        }

        public void UpdateScoreDisplay()
        {
            text.text = score.ToString();
        }
    }
}

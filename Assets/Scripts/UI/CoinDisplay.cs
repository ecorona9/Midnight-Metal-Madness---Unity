// SUMMARY:
// 
// Requires Text component. Updates the text every time a coin is picked up
//
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MidnightMetalMadness
{
    public class CoinDisplay : MonoBehaviour
    {
        private TextMeshProUGUI text;
        private Animator animator;
        private int coin_count;

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            coin_count = 0;
        }

        public void IncreaseCoinCount()
        {
            coin_count++;
            animator.SetTrigger("CoinIncrease");
            text.text = "X " + coin_count.ToString();
        }
    }
}

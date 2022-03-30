// SUMMARY:
// 
// Requires Text component. Updates the text every time a coin is picked up
//
using UnityEngine;
using UnityEngine.UI;

namespace MidnightMetalMadness
{
    [RequireComponent(typeof(Text), typeof(Animator))]
    public class CoinDisplay : MonoBehaviour
    {
        private Text text;
        private Animator animator;
        private int coin_count;

        private void Awake()
        {
            text = GetComponent<Text>();
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
            text.text = "x " + coin_count.ToString();
        }
    }
}

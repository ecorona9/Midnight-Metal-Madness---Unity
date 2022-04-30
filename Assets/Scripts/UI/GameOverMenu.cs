/* Summary:
 * 
 * This script has the contains functions for the GameOver Canvas
 * 
 */
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MidnightMetalMadness.UI
{
    public class GameOverMenu : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void ShowGameOverMenu()
        {
            animator.SetTrigger("Show Game Over");
        }

        public void HideGameOverMenu()
        {
            animator.SetTrigger("Hide Game Over");
        }

        public void Retry()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }

        public void QuitToMainMenu()
        {
            SceneManager.LoadSceneAsync("Menu-Scene");
        }
    }
}

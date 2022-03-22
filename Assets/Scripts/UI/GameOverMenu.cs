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
        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void ShowGameOverMenu()
        {
            gameObject.SetActive(true);
        }

        public void Retry()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}

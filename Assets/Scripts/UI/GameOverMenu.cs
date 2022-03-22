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
            EventManager.instance.OnPlayerDeath += ShowGameOverMenu;
            gameObject.SetActive(false);
        }

        private void ShowGameOverMenu()
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

        private void OnDestroy()
        {
            EventManager.instance.OnPlayerDeath += ShowGameOverMenu;
        }
    }
}

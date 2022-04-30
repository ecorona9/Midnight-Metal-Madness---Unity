/* Summary:
 * This script has the contains functions for the Pause Canvas
 */
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MidnightMetalMadness.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Animator pause_menu;

        public void ShowPauseMenu(bool condition)
        {
            if (condition)
            {
                pause_menu.SetTrigger("ShowPauseMenu");
            }
            else
            {
                pause_menu.SetTrigger("HidePauseMenu");
            }
        }

        public void Restart()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }

        public void QuitToMainMenu()
        {
            SceneManager.LoadSceneAsync("Menu-Scene");
        }
    }
}

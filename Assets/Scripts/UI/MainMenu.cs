using UnityEngine;
using UnityEngine.SceneManagement;

namespace MidnightMetalMadness.UI
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void QuitGame()
        {
            Debug.Log("QUIT!");
            Application.Quit();
        }
        public void Settings()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}

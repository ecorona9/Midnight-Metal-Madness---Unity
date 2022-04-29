using UnityEngine;
using UnityEngine.SceneManagement;

namespace MidnightMetalMadness.UI
{
    public class LevelSelect : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void LoadLevel(string levelName)
        {
            SceneManager.LoadSceneAsync(levelName);
        }

        public void ShowLevelSelect()
        {
            animator.SetTrigger("Show Level Select");
        }

        public void HideLevelSelect()
        {
            animator.SetTrigger("Hide Level Select");
        }
    }
}

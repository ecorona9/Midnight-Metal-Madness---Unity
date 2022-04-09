using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MidnightMetalMadness.UI
{
    public class LevelSelect : MonoBehaviour
    {
        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}

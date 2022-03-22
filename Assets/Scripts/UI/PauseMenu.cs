
/* Summary:
 * 
 * This script has the contains functions for the Pause Canvas
 * 
 */
using UnityEngine;

namespace MidnightMetalMadness.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Animator pause_menu;

        private void Start()
        {
            EventManager.instance.OnPlayerPause += ShowPauseMenu;
            EventManager.instance.OnPlayerUnpause += HidePauseMenu;
        }

        private void HidePauseMenu()
        {
            pause_menu.SetTrigger("HidePauseMenu");
        }

        private void ShowPauseMenu()
        {
            pause_menu.SetTrigger("ShowPauseMenu");
        }

        private void OnDestroy()
        {
            EventManager.instance.OnPlayerPause -= ShowPauseMenu;
            EventManager.instance.OnPlayerUnpause -= HidePauseMenu;
        }
    }
}

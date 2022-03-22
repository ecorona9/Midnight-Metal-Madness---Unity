
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
    }
}

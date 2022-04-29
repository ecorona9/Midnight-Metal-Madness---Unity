/* Summary:
 * SettingsMenu hides and shows the settings menu
 */
using UnityEngine;

namespace MidnightMetalMadness.UI
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private Animator settings_menu;

        public void ShowMenu(bool condition)
        {
            if (condition)
            {
                settings_menu.SetTrigger("ShowSettingsMenu");
            } 
            else
            {
                settings_menu.SetTrigger("HideSettingsMenu");
            }
        }

        // Close settings menu if escaped key is pressed
        public void HideMenuOnPauseKeyPressed(bool condition)
        {
            if (!condition)
            {
                settings_menu.SetTrigger("HideSettingsMenu");
            }
        }
    }
}

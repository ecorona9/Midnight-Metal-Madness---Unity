/* SUMMARY:
 * SettingsPageSelect manages which page to display in the settings menu
 */
using UnityEngine;
using UnityEngine.UI;

namespace MidnightMetalMadness.UI
{
    public class SettingsPageSelect : MonoBehaviour
    {        
        [SerializeField] private CanvasGroup keybinds_page;
        [SerializeField] private CanvasGroup volume_page;
        [SerializeField] private CanvasGroup quality_page;
        [SerializeField] private CanvasGroup help_page;

        
        public void OnSettingMenuEnabled()
        {
            // keybinds page is first option, so will be displayed by default
            keybinds_page.alpha = 1f;
            volume_page.alpha = quality_page.alpha = help_page.alpha = 0f;
        }
    }
}

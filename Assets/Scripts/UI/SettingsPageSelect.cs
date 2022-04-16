/* SUMMARY:
 * SettingsPageSelect manages which page to display in the settings menu
 */
using UnityEngine;
using UnityEngine.UI;

namespace MidnightMetalMadness.UI
{
    public class SettingsPageSelect : MonoBehaviour
    {        
        [SerializeField] private CanvasGroup keybinds_page;     // page 0
        [SerializeField] private CanvasGroup volume_page;       // page 1
        [SerializeField] private CanvasGroup quality_page;      // page 2
        [SerializeField] private CanvasGroup help_page;         // page 3

        private CanvasGroup current_page;

        public void OnSettingMenuEnabled()
        {
            if (keybinds_page == null) return;
            // keybinds page is first option, so will be displayed by default
            keybinds_page.alpha = 1f;
            volume_page.alpha = quality_page.alpha = help_page.alpha = 0f;
            current_page = keybinds_page;
        }

        public void EnableKeybindPage()
        {
            if (keybinds_page == null) return;

            if (current_page != keybinds_page)
            {
                FadeOutSelectedPage();
                FadeInSelectedPage(keybinds_page);
            }
        }

        public void EnableVolumePage()
        {
            if (volume_page == null) return;

            if (current_page != volume_page)
            {
                FadeOutSelectedPage();
                FadeInSelectedPage(volume_page);
            }
        }

        public void EnableQualityPage()
        {
            if (quality_page == null) return;

            if (current_page != quality_page)
            {
                FadeOutSelectedPage();
                FadeInSelectedPage(quality_page);
            }
        }

        public void EnableHelpPage()
        {
            if (help_page == null) return;

            if (current_page != help_page)
            {
                FadeOutSelectedPage();
                FadeInSelectedPage(help_page);
            }
        }

        private void FadeOutSelectedPage()
        {

        }

        private void FadeInSelectedPage(CanvasGroup page)
        {

        }
    }
}

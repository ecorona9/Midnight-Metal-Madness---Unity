/* SUMMARY:
 * SettingsPageSelect manages which page to display in the settings menu
 */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MidnightMetalMadness.UI
{
    public class SettingsPageSelect : MonoBehaviour
    {         
        [SerializeField] private CanvasGroup quality_page;   
        [SerializeField] private CanvasGroup volume_page;                 
        [SerializeField] private CanvasGroup help_page;
        [SerializeField] private float fade_duration = 0.25f;

        private CanvasGroup current_page;

        // keybinds page is first option, so will be displayed by default
        public void OnSettingMenuEnabled()
        {
            if (quality_page == null) return;
            
            quality_page.alpha = 1f;
            volume_page.alpha = help_page.alpha = 0f;
            current_page = quality_page;

            volume_page.gameObject.SetActive(false);
            help_page.gameObject.SetActive(false);
        }

        public void EnableQualityPage()
        {
            if (quality_page == null) return;

            if (current_page != quality_page)
            {
                StartCoroutine(FadeOutCurrentPage());
                StartCoroutine(FadeInSelectedPage(quality_page));
            }
        }

        public void EnableVolumePage()
        {
            if (volume_page == null) return;

            if (current_page != volume_page)
            {
                StartCoroutine(FadeOutCurrentPage());
                StartCoroutine(FadeInSelectedPage(volume_page));
            }
        }

        public void EnableHelpPage()
        {
            if (help_page == null) return;

            if (current_page != help_page)
            {
                StartCoroutine(FadeOutCurrentPage());
                StartCoroutine(FadeInSelectedPage(help_page));
            }
        }

        private IEnumerator FadeOutCurrentPage()
        {
            float init_alpha = 1f;
            float time = 0f;
            while (time < fade_duration)
            {
                current_page.alpha = Mathf.Lerp(init_alpha, 0f, time / fade_duration);
                time += Time.unscaledDeltaTime;
                yield return null;
            }
            current_page.alpha = 0f;
            current_page.gameObject.SetActive(false);
        }

        private IEnumerator FadeInSelectedPage(CanvasGroup page)
        {
            float init_alpha = 0f;
            float time = 0f;
            while (time < fade_duration)
            {
                page.alpha = Mathf.Lerp(init_alpha, 1f, time / fade_duration);
                time += Time.unscaledDeltaTime;
                yield return null;
            }
            current_page = page;
            current_page.gameObject.SetActive(true);
        }
    }
}

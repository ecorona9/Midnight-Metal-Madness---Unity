/*
 * SUMMARY:
 * QualityPage Sets the quality level of the game
 */

using UnityEngine;
using UnityEngine.UI;

namespace MidnightMetalMadness.UI
{
    public class QualityPage : MonoBehaviour
    {
        [Header("Make sure list order is low -> medium -> high")]
        [SerializeField] private Button[] qualities;
        [SerializeField] private RectTransform selected_pointer;

        private void Awake()
        {
            SetQualityLevel(PlayerPrefs.GetInt(SettingPreferences.qualityLevel, 1));
        }

        public void SetLowQuality()
        {
            if (PlayerPrefs.GetInt(SettingPreferences.qualityLevel) == 0) return;

            SetQualityLevel(0);
        }

        public void SetMediumQuality()
        {
            if (PlayerPrefs.GetInt(SettingPreferences.qualityLevel) == 1) return;

            SetQualityLevel(1);
        }

        public void SetHighQuality()
        {
            if (PlayerPrefs.GetInt(SettingPreferences.qualityLevel) == 2) return;

            SetQualityLevel(2);
        }

        private void SetQualityLevel(int level)
        {
            QualitySettings.SetQualityLevel(level, true);
            UpdateQualityUI(level);
            PlayerPrefs.SetInt(SettingPreferences.qualityLevel, level);
            PlayerPrefs.Save();
        }

        // Move the selected pointer over the current quality level
        private void UpdateQualityUI(int level)
        {
            if (level == 0)
            {
                selected_pointer.anchoredPosition = new Vector2(-400f, 110f);
            }
            else if (level == 1)
            {
                selected_pointer.anchoredPosition = new Vector2(0f, 110f);
            }
            else
            {
                selected_pointer.anchoredPosition = new Vector2(400f, 110f);
            }
        }

    }
}

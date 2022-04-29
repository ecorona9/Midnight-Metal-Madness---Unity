/* SUMMARY:
 * VolumeAdjuster adjusts the slider for each of the volume types
 */
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MidnightMetalMadness.UI
{
    public class VolumeAdjuster : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;

        private void Start()
        {
            SetVolume(SettingPreferences.masterVolume, 
                      PlayerPrefs.GetFloat(SettingPreferences.masterVolume, 0.5f));

            SetVolume(SettingPreferences.musicVolume,
                      PlayerPrefs.GetFloat(SettingPreferences.musicVolume, 0.5f));

            SetVolume(SettingPreferences.sfxVolume,
                      PlayerPrefs.GetFloat(SettingPreferences.sfxVolume, 0.5f));
        }

        // Exposed Param in Audio Mixer must be equal to key
        private void SetVolume(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.Save();
            mixer.SetFloat(key, Mathf.Log10(value) * 20);
        }

        public void AdjustMasterVolume(float value)
        {
            SetVolume(SettingPreferences.masterVolume, value);
        }

        public void AdjustMusicVolume(float value)
        {
            SetVolume(SettingPreferences.musicVolume, value);
        }

        public void AdjustSFXVolume(float value) 
        { 
            SetVolume(SettingPreferences.sfxVolume, value); 
        }
    }
}

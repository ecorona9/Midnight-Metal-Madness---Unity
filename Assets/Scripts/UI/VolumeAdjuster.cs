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
            SetVolume(VolumePreferences.masterVolume, 
                      PlayerPrefs.GetFloat(VolumePreferences.masterVolume, 0.5f));

            SetVolume(VolumePreferences.musicVolume,
                      PlayerPrefs.GetFloat(VolumePreferences.musicVolume, 0.5f));

            SetVolume(VolumePreferences.sfxVolume,
                      PlayerPrefs.GetFloat(VolumePreferences.sfxVolume, 0.5f));
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
            SetVolume(VolumePreferences.masterVolume, value);
        }

        public void AdjustMusicVolume(float value)
        {
            SetVolume(VolumePreferences.musicVolume, value);
        }

        public void AdjustSFXVolume(float value) 
        { 
            SetVolume(VolumePreferences.sfxVolume, value); 
        }
    }
}

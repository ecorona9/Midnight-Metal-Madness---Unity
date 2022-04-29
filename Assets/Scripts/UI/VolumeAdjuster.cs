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
        [SerializeField] private Slider master;
        [SerializeField] private Slider music;
        [SerializeField] private Slider sfx;

        private void Start()
        {
            var mastervol = PlayerPrefs.GetFloat(SettingPreferences.masterVolume, 0.5f);
            var musicvol = PlayerPrefs.GetFloat(SettingPreferences.musicVolume, 0.5f);
            var sfxvol = PlayerPrefs.GetFloat(SettingPreferences.sfxVolume, 0.5f);

            SetVolume(SettingPreferences.masterVolume, mastervol);

            SetVolume(SettingPreferences.musicVolume, musicvol);

            SetVolume(SettingPreferences.sfxVolume, sfxvol);

            master.value = mastervol;
            music.value = musicvol;
            sfx.value = sfxvol;
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

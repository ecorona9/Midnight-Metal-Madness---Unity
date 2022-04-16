/*  File Description:
 *  AudioManager is a class that controls which audio clips are played. Attached this to main camera
 */
using UnityEngine;

namespace MidnightMetalMadness
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance { get; private set; }

        [SerializeField] private AudioSource music;

        [SerializeField] private AudioSource sfx;

        [SerializeField] private AudioClip pistol;

        [SerializeField] private AudioClip ar75;

        [SerializeField] private AudioClip bullx;

        [SerializeField] private AudioClip hawkshot;

        [SerializeField] private AudioClip zooka;

        [SerializeField] private AudioClip button;

        private void Awake()
        {
            instance = this;
        }

        public void PauseMusic()
        {
            music.Pause();
        }

        public void PlayMusic()
        {
            music.Play();
        }

        public void PlayZarpPistol()
        {
            sfx.PlayOneShot(pistol);
        }

        public void PlayAR75()
        {
            sfx.PlayOneShot(ar75);
        }

        public void PlayBullX()
        {
            sfx.PlayOneShot(bullx);
        }

        public void PlayHawkshot()
        {
            sfx.PlayOneShot(hawkshot);
        }

        public void PlayZ00ka()
        {
            sfx.PlayOneShot(zooka);
        }

        public void PlayLowHP()
        {
            sfx.Play();
        }

        public void PauseLowHP()
        {
            sfx.Pause();
        }

        public void PlayButtonSFX()
        {
            sfx.PlayOneShot(button);
        }
    }
}

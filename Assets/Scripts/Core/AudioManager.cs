/*  File Description:
 *  AudioManager is a class that controls which audio clips are played
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

        private void Awake()
        {
            instance = this;
        }

        public void PauseMusic()
        {
            music.Pause();
        }

        public void ResumeMusic()
        {
            music.Play();
        }

        public void PlayPistol()
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

        public void PlayZooka()
        {
            sfx.PlayOneShot(zooka);
        }
    }
}

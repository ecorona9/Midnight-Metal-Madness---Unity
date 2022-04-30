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

        [SerializeField] private AudioClip explode;

        [SerializeField] private AudioClip hurt;

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

        public void PlayButtonSFX()
        {
            sfx.PlayOneShot(button);
        }

        public void PlayExplosion()
        {
            sfx.PlayOneShot(explode);
        }

        public void PlayHurt()
        {
            sfx.PlayOneShot(hurt);
        }
    }
}

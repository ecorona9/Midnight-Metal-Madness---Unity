/*  File Description:
 *  AudioManager is a class that controls which audio clips are played
 */

using UnityEngine;

namespace MidnightMetalMadness
{
    public enum SoundEffects { Shoot, Jump, Run, PlayerHurt, EnemyHurt }

    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance { get; private set; }

        [SerializeField] private AudioSource music;

        [SerializeField] private AudioSource sfx;

        [SerializeField] private AudioClip shoot;

        [SerializeField] private AudioClip jump;

        [SerializeField] private AudioClip run;

        [SerializeField] private AudioClip player_hurt;

        [SerializeField] private AudioClip enemy_hurt;

        // TODO: Add more audio clips

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

        public void PlaySFX(SoundEffects audio_clip)
        {
            switch (audio_clip)
            {
                case SoundEffects.Shoot:
                    sfx.PlayOneShot(shoot);
                    break;
                case SoundEffects.Jump:
                    sfx.PlayOneShot(jump);
                    break;
                case SoundEffects.Run:
                    sfx.PlayOneShot(run);
                    break;
                case SoundEffects.PlayerHurt:
                    sfx.PlayOneShot(player_hurt);
                    break;
                case SoundEffects.EnemyHurt:
                    sfx.PlayOneShot(enemy_hurt);
                    break;
                default:
                    break;
            }
        }
    }
}

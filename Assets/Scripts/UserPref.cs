/*  File Description:
 *  UserPref is a class that contains the key for PlayerPref values
 */
using UnityEngine;

public class UserPref : MonoBehaviour
{
    public static UserPref instance { get; private set; }

    private const string HIGH_SCORE = "High Score";
    private const string MASTER_VOLUME = "Master Volume";
    private const string MUSIC_VOLUME = "Music Volume";
    private const string SFX_VOLUME = "SFX Volume";

    // Getters
    public string HighScore { get { return HIGH_SCORE; } }
    public string MasterVolume { get { return MASTER_VOLUME; } }
    public string MusicVolume { get { return MUSIC_VOLUME; } }
    public string SFXVolume { get { return SFX_VOLUME; } }

    // Setting default stats of PlayerPrefs key values
    private void Awake()
    {
        instance = this;

        if (!PlayerPrefs.HasKey(HIGH_SCORE))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
        }

        if (!PlayerPrefs.HasKey(MASTER_VOLUME))
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME, 0.5f);
        }

        if (!PlayerPrefs.HasKey(MUSIC_VOLUME))
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME, 0.5f);
        }

        if (!PlayerPrefs.HasKey(SFX_VOLUME))
        {
            PlayerPrefs.SetFloat(SFX_VOLUME, 0.5f);
        }
    }
}

using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioMixer theMixer;

    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            theMixer.SetFloat("MAster", PlayerPrefs.GetFloat("MasterVol"));
        }

        if (PlayerPrefs.HasKey("MusicVol"))
        {
            theMixer.SetFloat("Music", PlayerPrefs.GetFloat("MusicVol"));
        }

        if (PlayerPrefs.HasKey("SFXVol"))
        {
            theMixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFXVol"));
        }
    }
}

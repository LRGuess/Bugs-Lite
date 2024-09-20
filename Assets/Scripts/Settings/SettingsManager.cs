using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public Toggle fullscreenTog, VsyncTog;

    public List<ResItem> Resolutions = new List<ResItem>();
    public int SelectedResolution;

    public TMP_Text resolutionLabel;

    public AudioMixer theMixer;
    public TMP_Text MasterLabel, MusicLabel, SFXLabel;
    public Slider MasterSlider, MusicSlider, SFXSlider;

    void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        if (QualitySettings.vSyncCount == 0)
        {
            VsyncTog.isOn = false;
        }
        else
        {
            VsyncTog.isOn = true;
        }

        bool foundRes = false;
        for (int i = 0; i < Resolutions.Count; i++)
        {
            if (Screen.width == Resolutions[i].Horizontal && Screen.height == Resolutions[i].Vertical)
            {
                foundRes = true;

                SelectedResolution = i;

                UpdateResLabel();
            }
        }

        if (!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.Horizontal = Screen.width;
            newRes.Vertical = Screen.height;

            Resolutions.Add(newRes);
            SelectedResolution = Resolutions.Count - 1;

            UpdateResLabel();
        }

        float vol = 0f;
        theMixer.GetFloat("MAster", out vol);
        MasterSlider.value = vol;
        theMixer.GetFloat("Music", out vol);
        MusicSlider.value = vol;
        theMixer.GetFloat("SFX", out vol);
        SFXSlider.value = vol;

        MasterLabel.text = Mathf.RoundToInt(MasterSlider.value + 80).ToString() + " %";
        MusicLabel.text = Mathf.RoundToInt(MusicSlider.value + 80).ToString() + " %";
        SFXLabel.text = Mathf.RoundToInt(SFXSlider.value + 80).ToString() + " %";
    }

    public void ResLeft()
    {
        SelectedResolution--;
        if (SelectedResolution < 0)
        {
            SelectedResolution = 0;
        }

        UpdateResLabel();
    }

    public void ResRight()
    {
        SelectedResolution++;
        if (SelectedResolution > Resolutions.Count - 1)
        {
            SelectedResolution = Resolutions.Count - 1;
        }

        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = Resolutions[SelectedResolution].Horizontal.ToString() + " x " + Resolutions[SelectedResolution].Vertical.ToString();
    }

    public void ApplyGraphics()
    {
        Screen.fullScreen = fullscreenTog.isOn;

        if (VsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Screen.SetResolution(Resolutions[SelectedResolution].Horizontal, Resolutions[SelectedResolution].Vertical, fullscreenTog.isOn);
    }

    public void SetMasterVol()
    {
        MasterLabel.text = Mathf.RoundToInt(MasterSlider.value + 80).ToString() + " %";

        theMixer.SetFloat("MAster", MasterSlider.value);

        PlayerPrefs.SetFloat("MasterVol", MasterSlider.value);
    }

    public void SetMusicVol()
    {
        MusicLabel.text = Mathf.RoundToInt(MusicSlider.value + 80).ToString() + " %";

        theMixer.SetFloat("Music", MusicSlider.value);

        PlayerPrefs.SetFloat("MusicVol", MusicSlider.value);
    }

    public void SetSFXVol()
    {
        SFXLabel.text = Mathf.RoundToInt(SFXSlider.value + 80).ToString() + " %";

        theMixer.SetFloat("SFX", SFXSlider.value);

        PlayerPrefs.SetFloat("SFXVol", SFXSlider.value);
    }
}

[System.Serializable]
public class ResItem
{
    public int Horizontal, Vertical;
}
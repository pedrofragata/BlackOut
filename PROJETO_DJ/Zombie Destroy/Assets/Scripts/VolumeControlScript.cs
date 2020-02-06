using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class VolumeControlScript : MonoBehaviour
{
    public AudioMixer globalVolume;
    public void SetGlobalVolume(float masterVolume)
    {
        globalVolume.SetFloat("masterVolume", Mathf.Log10(masterVolume)*20);
    }

    public void SetMusicVolume(float musicVolume) {
        globalVolume.SetFloat("musicVolume", Mathf.Log10(musicVolume)*20);
    }

    public void SetSfxVolume(float sfxVolume)
    {
        globalVolume.SetFloat("sfxVolume", Mathf.Log10(sfxVolume) * 20);
    }
}

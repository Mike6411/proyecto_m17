using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public  AudioMixer audioMixer;
    
    public void SetVolumeMusic(float volume){

        audioMixer.SetFloat("volumeMusic", Mathf.Log10(volume) * 20);
    }
    public void SetVolumeSFX(float volume)
    {

        audioMixer.SetFloat("volumeSFX", Mathf.Log10(volume) * 20);
    }

}

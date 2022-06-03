using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioMixerConfigs : MonoBehaviour
{
    public AudioMixer audioMixer;

    public string audioGroup;

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat(audioGroup, volume);
    }
}

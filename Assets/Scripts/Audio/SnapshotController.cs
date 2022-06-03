using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SnapshotController : MonoBehaviour
{
    public AudioMixerSnapshot inGameAudioSnapshot;
    public AudioMixerSnapshot pauseAudioSnapshot;

    public GameObject pauseScreen;

    private bool IsScreenActive()
    {
        return pauseScreen.activeInHierarchy ? true : false;
    }

    public void SnapshotTransitionToggle()
    {
        if (IsScreenActive())
            pauseAudioSnapshot.TransitionTo(0.1f);
        else
            inGameAudioSnapshot.TransitionTo(0.1f);
    }
}

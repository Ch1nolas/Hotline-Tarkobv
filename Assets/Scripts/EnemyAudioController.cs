using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioController : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isInBox = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EnableAudio()
    {
        if (!isInBox)
        {
            audioSource.enabled = true;
        }
    }

    public void DisableAudio()
    {
        audioSource.enabled = false;
    }

    public void SetInBox(bool value)
    {
        isInBox = value;
    }
}

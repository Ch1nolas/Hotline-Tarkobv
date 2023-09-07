using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void EnableAudio()
    {
        audioSource.enabled = true;
    }

    public void DisableAudio()
    {
        audioSource.enabled = false;
    }

}

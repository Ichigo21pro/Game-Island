using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSourceEffects;
    public static SoundManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayASoundOneTime(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayASoundButWhitChange(AudioClip clip)
    {
        audioSourceEffects.pitch= Random.Range(0.0f, 1.0f);
        audioSourceEffects.volume= Random.Range(0.0f, 1.0f);
        audioSourceEffects.clip = clip;
        audioSourceEffects.Play();
    }
}

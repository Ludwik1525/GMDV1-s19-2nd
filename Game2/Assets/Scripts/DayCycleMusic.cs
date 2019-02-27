using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DayCycleMusic : MonoBehaviour
{


    public AudioClip dayMusic;
    public AudioClip nightMusic;
    public AudioSource source;
    private bool isPlayingDay = false;
    private bool isPlayingNight = false;

    void Start () {
		
	}

    public static IEnumerator FadeOutIn(AudioSource audioSource, AudioClip clip, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }

    public void PlayDayMusic()
    {
        StartCoroutine(FadeOutIn(source, dayMusic, 3f));
    }

    public void PlayNightMusic()
    {
        StartCoroutine(FadeOutIn(source, nightMusic, 3f));
    }

    void Update()
    {
        if (this.gameObject.transform.rotation.eulerAngles.x < 178)
        {
            if(!isPlayingDay)
            {
                isPlayingDay = true;
                isPlayingNight = false;
                PlayDayMusic();
            }
        }

        else
        {
            if(!isPlayingNight)
            {
                isPlayingDay = false;
                isPlayingNight = true;
                PlayNightMusic();
            }
        }
    }
}

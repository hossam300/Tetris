using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : StaticInstance<AudioManager>
{
    [SerializeField] AudioSource FXSource;
    [SerializeField] public AudioSource MainSource;
    public void PlaySoundMainSource(AudioClip clip)
    {
        if (MainSource.clip != clip)
        {
            MainSource.Stop();
            MainSource.clip = clip;
            MainSource.Play();
        }

    }
    public void StopSoundFxSource()
    {
        FXSource.Stop();
    }

    //public void StopSoundMainSource()
    //{
    //    MainSource.clip = null;
    //    MainSource.Stop();
    //}
    public void PlaySoundFxSource(AudioClip clip)
    {
        if (MainSource.clip != clip)
        {
            FXSource.Stop();
            FXSource.clip = clip;
            FXSource.Play();
        }
    }
}

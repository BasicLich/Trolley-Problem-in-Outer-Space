using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public TMP_Animated animatedText;
    private AudioSource mainSource;
    private AudioSource secondSource;

    [SerializeField]
    AudioClip[] music;

    public float maxVolume;
    [Space]
    public float fadeSpeed;
    bool mainIsPlaying;

    private class Source
    {
        public AudioSource source;
        public bool isFadingIn;
        public bool isFadingOut;

        public Source(AudioSource source)
        {
            this.source = source;
            isFadingIn = false;
            isFadingOut = false;
        }
    }
    Source MainSource, SecondSource;

    void Start()
    {
        mainSource = GetComponents<AudioSource>()[0];
        secondSource = GetComponents<AudioSource>()[1];
        MainSource = new Source(mainSource);
        SecondSource = new Source(secondSource);

        mainIsPlaying = false;
        mainSource.volume = 0;
        secondSource.volume = 0;

        changeMusic(Emotion.normal);

        animatedText.onEmotionChange.AddListener((Emotion) => changeMusic(Emotion));
    }

    void changeMusic(Emotion newEmotion)
    {
        AudioClip newClip = music[(int)newEmotion];
        if (mainIsPlaying)
        {
            secondSource.clip = newClip;
            StartCoroutine(fadeIn(SecondSource));
            StartCoroutine(fadeOut(MainSource));
            secondSource.Play();
            mainIsPlaying = false;
        }
        else
        {
            mainSource.clip = newClip;
            StartCoroutine(fadeIn(MainSource));
            StartCoroutine(fadeOut(SecondSource));
            mainSource.Play();
            mainIsPlaying = true;
        }
    }

    IEnumerator fadeIn(Source x)
    {
        x.isFadingIn = true;
        x.isFadingOut = false;

        AudioSource source = x.source;
        float newVolume = source.volume;
        while(source.volume < maxVolume && x.isFadingIn)
        {
            newVolume += fadeSpeed;
            source.volume = newVolume;
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    IEnumerator fadeOut(Source x)
    {
        x.isFadingIn = false;
        x.isFadingOut = true;

        AudioSource source = x.source;
        float newVolume = source.volume;
        while (source.volume >= 0 && x.isFadingOut)
        {
            newVolume -= fadeSpeed;
            if (newVolume < 0) newVolume = 0;
            source.volume = newVolume;
            yield return new WaitForSeconds(0.1f);
        }
    }

}

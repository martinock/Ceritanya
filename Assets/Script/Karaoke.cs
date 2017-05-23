using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class Karaoke : MonoBehaviour
{
#if UNITY_ANDROID
#else
    private MovieTexture movie;
    private AudioSource audioKaraoke;
#endif
    public GameObject finishedPanel;
    public Button playButton;
    public Button muteButton;
    public Button homeButton;
    public Button continueButton;
    public Button repeatButton;
    public Sprite play;
    public Sprite pause;
    private bool isPause = false;

    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
        Handheld.PlayFullScreenMovie("Basdat H-8.mp4", Color.black, FullScreenMovieControlMode.Full, FullScreenMovieScalingMode.AspectFill);
#else
        switch (GamesVariables.songSelection)
        {
            case 0:
                movie = Resources.Load("1") as MovieTexture;
                break;
            default:
                movie = Resources.Load("1") as MovieTexture;
                break;
        }
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audioKaraoke = GetComponent<AudioSource>();
        audioKaraoke.clip = movie.audioClip;

        playButton.onClick.AddListener(PlayOrPause);
        muteButton.onClick.AddListener(Mute);
        homeButton.onClick.AddListener(PauseMovie);
        continueButton.onClick.AddListener(PlayMovie);
        repeatButton.onClick.AddListener(Repeat);

        PlayMovietillEnd(ShowPanel);
#endif
    }

    void PlayOrPause()
    {
#if UNITY_ANDROID
#else
        if (movie.isPlaying)
        {
            PauseMovie();
            playButton.GetComponent<Image>().sprite = play;
        }
        else
        {
            PlayMovie();
            playButton.GetComponent<Image>().sprite = pause;
        }
#endif
    }

    void Mute()
    {
#if UNITY_ANDROID
#else
        if (!audioKaraoke.mute)
        {
            audioKaraoke.mute = true;
        }
        else
        {
            audioKaraoke.mute = false;
        }
#endif
    }

    void PlayMovie()
    {
#if UNITY_ANDROID
#else
        isPause = false;
        movie.Play();
#endif
    }

    void PauseMovie()
    {
#if UNITY_ANDROID
#else
        isPause = true;
        movie.Pause();
#endif
    }

    void Repeat()
    {
#if UNITY_ANDROID
#else
        movie.Stop();
        audioKaraoke.Stop();
        movie.Play();
        audioKaraoke.Play();
#endif
    }

    private void ShowPanel()
    {
#if UNITY_ANDROID
#else
        finishedPanel.SetActive(true);
        playButton.interactable = false;
        muteButton.interactable = false;
        homeButton.interactable = false;
#endif
    }

    private void PlayMovietillEnd(Action callback)
    {
#if UNITY_ANDROID
        
#else
        movie.Play();
        audioKaraoke.Play();
#endif
        StartCoroutine(FindEnd(callback));
    }

    private IEnumerator FindEnd(Action callback)
    {
#if UNITY_ANDROID
        yield return 0;
#else
        while (movie.isPlaying || isPause)
        {
            yield return 0;
        }

        callback();
        yield break;
#endif
    }
}

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
    public Button playButton;
    public Button muteButton;
    public Button homeButton;
    public Button continueButton;
    public Button repeatButton;
    public Sprite play;
    public Sprite pause;
    private bool isPause = false;
#endif
    public GameObject finishedPanel;

    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
        StartCoroutine(PlayVideoCoroutine("asd.mp4"));
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

#if UNITY_ANDROID
    private IEnumerator PlayVideoCoroutine(string videoPath)
    {
        Handheld.PlayFullScreenMovie(videoPath, Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFill);
        yield return new WaitForEndOfFrame();
        ShowPanel();
    }
#else
    void PlayOrPause()
    {
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
    }

    void Mute()
    {
        if (!audioKaraoke.mute)
        {
            audioKaraoke.mute = true;
        }
        else
        {
            audioKaraoke.mute = false;
        }
    }

    void PlayMovie()
    {
        isPause = false;
        movie.Play();
    }

    void PauseMovie()
    {
        isPause = true;
        movie.Pause();
    }

    void Repeat()
    {
        movie.Stop();
        audioKaraoke.Stop();
        movie.Play();
        audioKaraoke.Play();
    }

    private void PlayMovietillEnd(Action callback)
    {
        movie.Play();
        audioKaraoke.Play();
        StartCoroutine(FindEnd(callback));
    }

    private IEnumerator FindEnd(Action callback)
    {
        while (movie.isPlaying || isPause)
        {
            yield return 0;
        }

        callback();
        yield break;
    }
#endif
    private void ShowPanel()
    {
        finishedPanel.SetActive(true);
#if UNITY_DESKTOP
        playButton.interactable = false;
        muteButton.interactable = false;
        homeButton.interactable = false;
#endif
    }
}

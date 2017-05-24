using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class MoviePlayer : MonoBehaviour {

#if UNITY_ANDROID

#else
    private MovieTexture movie;
    private AudioSource audioMovie;
    public Button playButton;
    public Sprite play;
    public Sprite pause;
    private bool isPause = false;
#endif

    // Use this for initialization
    void Start() {
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
        audioMovie = GetComponent<AudioSource>();
        audioMovie.clip = movie.audioClip;

        playButton.onClick.AddListener(PlayOrPause);

        PlayMovietillEnd(LoadScene);
#endif
    }

#if UNITY_ANDROID
    private IEnumerator PlayVideoCoroutine(string videoPath)
    {
        Handheld.PlayFullScreenMovie(videoPath, Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFill);
        yield return new WaitForEndOfFrame();

        LoadScene();
    }
#else
    private void PlayMovietillEnd(Action callback)
    {
        movie.Play();
        audioMovie.Play();
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

    void PlayOrPause()
    {
        if (movie.isPlaying)
        {
            isPause = true;
            movie.Pause();
            playButton.GetComponent<Image>().sprite = play;
        } else
        {
            isPause = false;
            movie.Play();
            playButton.GetComponent<Image>().sprite = pause;
        }
    }

    void NextSong()
    {

    }

    void PrevSong()
    {

    }
#endif
    private void LoadScene()
    {
        SceneManager.LoadScene(5);
    }
}

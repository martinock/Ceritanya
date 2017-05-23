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
#endif
    public Button playButton;
    public Sprite play;
    public Sprite pause;
    private bool isPause = false;

    // Use this for initialization
    void Start() {
#if UNITY_ANDROID
        Handheld.PlayFullScreenMovie("Assets/Resources/1");
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

    private void PlayMovietillEnd(Action callback)
    {
#if UNITY_ANDROID
        
#else
        movie.Play();
        audioMovie.Play();
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

    private void LoadScene()
    {
        SceneManager.LoadScene(5);
    } 

    void PlayOrPause()
    {
#if UNITY_ANDROID
#else
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
#endif
    }

    void NextSong()
    {

    }

    void PrevSong()
    {

    }
}

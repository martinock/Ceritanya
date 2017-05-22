using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class MoviePlayer : MonoBehaviour {

    private MovieTexture movie;
    public Button playButton;
    public Sprite play;
    public Sprite pause;
    private AudioSource audio;
    private bool isPause = false;

    // Use this for initialization
    void Start() {
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
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;

        playButton.onClick.AddListener(PlayOrPause);

        PlayMovietillEnd(LoadScene);
    }

    private void PlayMovietillEnd(Action callback)
    {
        movie.Play();
        audio.Play();
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

    private void LoadScene()
    {
        SceneManager.LoadScene(6);
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
}

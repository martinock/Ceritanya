using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class Karaoke : MonoBehaviour
{

    private MovieTexture movie;
    public Button playButton;
    public Button muteButton;
    public Button homeButton;
    public Button continueButton;
    public Button repeatButton;
    public Sprite play;
    public Sprite pause;
    private AudioSource audio;

    // Use this for initialization
    void Start()
    {
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
        muteButton.onClick.AddListener(Mute);
        homeButton.onClick.AddListener(PauseMovie);
        continueButton.onClick.AddListener(PlayMovie);
        repeatButton.onClick.AddListener(Repeat);

        movie.Play();
        audio.Play();
    }

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
        if (!audio.mute)
        {
            audio.mute = true;
        }
        else
        {
            audio.mute = false;
        }
    }

    void PlayMovie()
    {
        movie.Play();
    }

    void PauseMovie()
    {
        movie.Pause();
    }

    void Repeat()
    {
        movie.Stop();
        audio.Stop();
        movie.Play();
        audio.Play();
    }
}

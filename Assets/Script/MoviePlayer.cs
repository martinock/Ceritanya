using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]

public class MoviePlayer : MonoBehaviour {

    private MovieTexture movie;
    public Button playButton;
    public Sprite play;
    public Sprite pause;
    private AudioSource audio;

	// Use this for initialization
	void Start () {
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

        movie.Play();
        audio.Play();
	}

    void PlayOrPause()
    {
        if (movie.isPlaying)
        {
            movie.Pause();
            playButton.GetComponent<Image>().sprite = play;
        } else
        {
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

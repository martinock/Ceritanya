using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPageSingleton : MonoBehaviour {

    private static MainPageSingleton instance = null;

    public static MainPageSingleton Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex > 4)
        {
            GetComponent<AudioSource>().mute = true;
        } else
        {
            if (scene.buildIndex == 1)
            {
                GetComponent<AudioSource>().Play();
            }
            GetComponent<AudioSource>().mute = false;
        }
    }
}

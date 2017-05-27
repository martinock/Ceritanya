using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject finishedPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (IsGameOver())
        {
            finishedPanel.SetActive(true);
        }
	}

    private bool IsGameOver()
    {
        return (GamesVariables.IsPamanTrue && 
            GamesVariables.IsPisangTrue &&
            GamesVariables.IsRambutanTrue &&
            GamesVariables.IsSayurTrue &&
            GamesVariables.IsTernakTrue);
    }
}

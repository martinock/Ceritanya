using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonTrueClick : MonoBehaviour {
    public void PamanTrue(Boolean x)
    {
        GamesVariables.IsPamanTrue = x;
    }

    public void PisangTrue(Boolean x)
    {
        GamesVariables.IsPisangTrue = x;
    }

    public void SayurTrue(Boolean x)
    {
        GamesVariables.IsSayurTrue = x;
    }

    public void TernakTrue(Boolean x)
    {
        GamesVariables.IsTernakTrue = x;
    }

    public void RambutanTrue(Boolean x)
    {
        GamesVariables.IsRambutanTrue = x;
    }

    public void GameFinished(Boolean x)
    {
        GamesVariables.IsGameFinished = x;
    }
}

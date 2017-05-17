using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonTrueClick : MonoBehaviour {
    public void PamanTrue(Boolean x)
    {
        GamesTebakHuruf.IsPamanTrue = x;
    }

    public void PisangTrue(Boolean x)
    {
        GamesTebakHuruf.IsPisangTrue = x;
    }

    public void SayurTrue(Boolean x)
    {
        GamesTebakHuruf.IsSayurTrue = true;
    }

    public void TernakTrue(Boolean x)
    {
        GamesTebakHuruf.IsTernakTrue = true;
    }

    public void RambutanTrue(Boolean x)
    {
        GamesTebakHuruf.IsRambutanTrue = true;
    }
}

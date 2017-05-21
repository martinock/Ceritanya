using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelBehaviour : MonoBehaviour {

    public GameObject panelEmpty;
    public GameObject panelFilled;
    private GameObject go;


    public void OnPanelShow()
    {
        switch(EventSystem.current.currentSelectedGameObject.name)
        {
            case "Paman":
                if (GamesVariables.IsPamanTrue)
                {
                    panelFilled.SetActive(true);
                }
                else
                {
                    panelEmpty.SetActive(true);
                }
                break;

            case "Pisang":
                if (GamesVariables.IsPisangTrue)
                {
                    panelFilled.SetActive(true);
                }
                else
                {
                    panelEmpty.SetActive(true);
                }
                break;

            case "Rambutan":
                if (GamesVariables.IsRambutanTrue)
                {
                    panelFilled.SetActive(true);
                }
                else
                {
                    panelEmpty.SetActive(true);
                }
                break;

            case "Ternak":
                if (GamesVariables.IsTernakTrue)
                {
                    panelFilled.SetActive(true);
                }
                else
                {
                    panelEmpty.SetActive(true);
                }
                break;

            case "Sayur":
                if (GamesVariables.IsSayurTrue)
                {
                    panelFilled.SetActive(true);
                }
                else
                {
                    panelEmpty.SetActive(true);
                }
                break;
        }        
    }
}

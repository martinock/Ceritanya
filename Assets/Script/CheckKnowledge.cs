using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckKnowledge : MonoBehaviour {

    public Button permainan;
    public Button nyanyian;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("has_knowledge"))
        {
            permainan.interactable = true;
            nyanyian.interactable = true;
        }

        //PlayerPrefs.DeleteAll(); //This is for Debugging purpose
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

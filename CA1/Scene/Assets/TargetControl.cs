using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour {

    int score;
    GameObject scoreboard;
    string input;
	// Use this for initialization
	void Start () {

        scoreboard = GameObject.FindGameObjectWithTag("ScoreTxt");

  


    }
	
	// Update is called once per frame
	void Update () {
        input = "Score: " + score;
		
	}

        private void OnTriggerEnter(Collider collision)
    {




        score += 5;
        

   


    }

    private void OnGUI()
    {
        GUI.Label(new Rect(200, 100, 0, 0), input);
    }
}

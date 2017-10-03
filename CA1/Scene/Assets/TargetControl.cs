using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetControl : MonoBehaviour {

    int score;
    string scoreinput;
    public Text scoreboard;
	// Use this for initialization
	void Start () {

   


  


    }
	
	// Update is called once per frame
	void Update () {
        
        scoreinput = "Score: " + score;
        scoreboard.text = scoreinput;
		
	}

        private void OnTriggerEnter(Collider collision)
    {




        score += 5;
        

    }


}

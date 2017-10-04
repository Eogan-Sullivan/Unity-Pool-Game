using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueController : MonoBehaviour
{

    private CodedSphere ballScript;
    private Camera ballcam;
    private int timer;
    // Use this for initialization
    void Start()
    {
        ballScript = this.GetComponent<CodedSphere>();
        ballcam = this.GetComponentInChildren <Camera>();
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer == 3)
        {
            if (Input.GetMouseButtonUp(0))
            {
                ballScript.velocity = 9.8f * (3f * ballcam.transform.forward);
                timer--;

            }
        }
        else
            timer++;
       
 

        if (Input.GetMouseButtonUp(1))
        {
            ballScript.velocity = 9.8f * (2f * ballcam.transform.up);

        }

       
    }
}


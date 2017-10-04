using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocketControler : MonoBehaviour {

    TargetControl target;
	// Use this for initialization
	void Start () {
        target = gameObject.GetComponent<TargetControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
       
        CodedSphere otherSphere = collision.gameObject.GetComponent<CodedSphere>();
        if (!otherSphere.GetComponent<CueController>())
        {
            Destroy(otherSphere.gameObject);
            target.score += 10;
        }

      
       


    }
}

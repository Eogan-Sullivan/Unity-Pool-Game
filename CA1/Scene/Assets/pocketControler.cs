using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocketControler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {


       
       
            CodedSphere otherSphere = collision.gameObject.GetComponent<CodedSphere>();
        if (!otherSphere.GetComponent<CueController>())
            Destroy(otherSphere.gameObject);
      
       


    }
}

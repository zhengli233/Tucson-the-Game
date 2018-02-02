using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDoor : MonoBehaviour {
    public bool isEnter;
	// Use this for initialization
	void Start () {
        isEnter = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide!");
        isEnter = true;
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            GameManager.enterUpDoor = true;
            Debug.Log("enter!");
        }
    }
}

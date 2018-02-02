using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFinal : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.SetAsLastSibling();
        Invoke("ChangeSceneToMaze", 2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

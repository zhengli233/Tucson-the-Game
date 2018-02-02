using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour {

    public GameObject load;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        Invoke("ToOpening", 2f);
    }

    public void ToOpening()
    {
        SceneManager.LoadScene("Opening");
    }
}

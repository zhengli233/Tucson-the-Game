using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBar : MonoBehaviour {

    

    // Use this for initialization
    void Start () {
        gameObject.transform.SetAsLastSibling();
        Invoke("ChangeSceneToBar", 2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeSceneToBar()
    {        
        SceneManager.LoadScene("Bar");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMap1 : MonoBehaviour {

    public static bool fromMap2;

	// Use this for initialization
	void Start () {
        gameObject.transform.SetAsLastSibling();
        Invoke("ChangeSceneToMap1", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeSceneToMap1()
    {
        fromMap2 = true;
        SceneManager.LoadScene("Map1");
    }
}

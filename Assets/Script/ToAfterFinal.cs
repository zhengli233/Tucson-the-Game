using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToAfterFinal : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.SetAsLastSibling();
        Invoke("ChangeSceneToAfterFinal", 2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeSceneToAfterFinal()
    {
        GameManager.fightedProfessor = true;
        SceneManager.LoadScene("AfterFinal");
    }
}

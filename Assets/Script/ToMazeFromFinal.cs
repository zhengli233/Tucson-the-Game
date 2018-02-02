using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMazeFromFinal : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.SetAsLastSibling();
        Invoke("ChangeSceneToMaze", 2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeSceneToMaze()
    {
        GameManager.fightedProfessor = true;
        SceneManager.LoadScene("AfterFinal");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPaper : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.SetAsLastSibling();
        Invoke("Win", 2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Win()
    {
        GameManager.fromPaperBattle = true;
        SceneManager.LoadScene("Map1");
    }
}

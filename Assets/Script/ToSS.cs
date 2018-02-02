using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ToSS : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.SetAsLastSibling();
        Invoke("ChangeSceneToSS", 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSceneToSS()
    {
        SceneManager.LoadScene("SportsStore");
    }
}

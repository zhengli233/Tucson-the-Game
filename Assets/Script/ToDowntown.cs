using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToDowntown : MonoBehaviour {

    void Start()
    {
        gameObject.transform.SetAsLastSibling();
        Invoke("ChangeSceneToDowntown", 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSceneToDowntown()
    {
        SceneManager.LoadScene("Downtown");
    }
}

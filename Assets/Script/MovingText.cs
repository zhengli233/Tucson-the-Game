using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingText : MonoBehaviour {

    public GameObject quit;

    RectTransform text;
    Vector2 pos;


	// Use this for initialization
	void Start () {
        //        text = GetComponent<RectTransform>();
        pos.x = 0;
        pos.y = -650;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (pos.y < 0)
        {
            Debug.Log(pos.y);
            transform.localPosition = pos;
            pos.y += 50 * Time.deltaTime;
        }
        else
        {
            quit.SetActive(true);
        }
        
	}
}

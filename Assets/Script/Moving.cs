using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour {

    Vector2 pos;
    public GameObject dialogPanel;
    public Text text;
    public GameObject end;

	// Use this for initialization
	void Start () {
        pos = transform.position;
        text.text = "Aliens: Approaching, Earth!";
        dialogPanel.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if (pos.x < 5.11f)
        {
            pos.x += 2 * Time.deltaTime;
            transform.position = pos;
        }
        else
        {
            dialogPanel.SetActive(false);
            end.SetActive(true);
        }
        
    }
}

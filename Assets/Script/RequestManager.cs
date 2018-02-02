using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequestManager : MonoBehaviour {
    public static bool inRequestMichael;
    public static bool inRequestNeil;

    public Text describe;

    bool returnCal;
    bool returnPen;

	// Use this for initialization
	void Start () {
        describe.text = "";
        inRequestMichael = false;
        inRequestNeil = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.calculatorGet)
        {
            returnCal = true;
        }
        if (GameManager.pencilGet)
        {
            returnPen = true;
        }
        if (GameManager.michaelRequestDone)
        {
            describe.text = "";
        }

        if (inRequestMichael)
        {
            describe.text = "Find the calculator";
        }       
        if (inRequestNeil)
        {
            describe.text = "Find the pencil";
        }
        if (returnCal)
        {
            describe.text = "Return the calculator to Michael";
            returnCal = false;
        }
        if (returnPen)
        {
            describe.text = "Return the pencil to Neil";
            returnPen = false;
        }        
    }
}

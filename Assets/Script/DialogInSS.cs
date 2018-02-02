using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogInSS : MonoBehaviour {

    public GameObject dialogPanel;
    public Text text;
    public TextAsset sarah;
    public TextAsset crazyCus;
    public TextAsset sarah2;

    public string[] textLines;
    int currentLine;
    int endLine;
    bool imported;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (InteractionInSS.dialogInSS != 0)
        {
            if (!imported)
                ImportFile(InteractionInSS.dialogInSS);
            EnableDialog();
        }
        if (dialogPanel.activeSelf)
            GameManager.lockPlayer = true;
        else
            GameManager.lockPlayer = false;
    }

    void ImportFile(int dialogNum)
    {
        if (dialogNum == 1)
        {
            if (sarah != null)
            {
                textLines = sarah.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.askedSarahInSS = true;
            }
        }
        if (dialogNum == 2)
        {
            if (crazyCus != null)
            {
                textLines = crazyCus.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.askedCrazyCusInSS = true;
            }
        }
        if (dialogNum == 3)
        {
            if (sarah2 != null)
            {
                textLines = sarah2.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.showFBI = true;
            }
        }
    }

    void EnableDialog()
    {
        dialogPanel.SetActive(true);
        text.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("space"))
        {
            if (currentLine < endLine - 1)
            {
                currentLine++;

            }
            else
            {
                
                dialogPanel.SetActive(false);
                imported = false;
                if (InteractionInSS.dialogInSS == 2)
                {
                    SceneManager.LoadScene("FightInSS");
                }

                InteractionInSS.dialogInSS = 0;
            }
        }
    }
}

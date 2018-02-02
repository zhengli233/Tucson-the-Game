using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {
    public Text text;
    public TextAsset professor;
    public TextAsset professor2;
    public TextAsset michael;
    public TextAsset michael2;
    public TextAsset michael3;
    public TextAsset neil;
    public TextAsset neil2;
    public TextAsset neil3;
    public TextAsset serah;
    public TextAsset sarah2;
    public TextAsset teacher;
    public TextAsset teacher2;
    public TextAsset meetFBIFloor3;
    public TextAsset meetFBIFloor1;
    public TextAsset intro;
    public GameObject dialogPanal;
    public GameObject calculator;
    public GameObject pencil;

    public string[] textLines;
    int currentLine;
    int endLine;
    bool imported;
    bool dialog5End;
	// Use this for initialization
	void Start () {
        dialogPanal.SetActive(false);
        calculator.SetActive(false);
        pencil.SetActive(false);
        imported = false;
        dialog5End = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.dialogMap1 != 0)
        {
            if(!imported)
                ImportFile(GameManager.dialogMap1);
            EnableDialog();
        }
        GameManager.fightScene = dialog5End;

        if (dialogPanal.activeSelf)
            GameManager.lockPlayer = true;
        else
            GameManager.lockPlayer = false;
    }

    void ImportFile(int dialogNum)
    {
        if (dialogNum == 1)
        {
            if (professor != null)
            {
                textLines = professor.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.askedProf = true;
            }
        }
        if (dialogNum == 2)
        {
            if (michael != null)
            {
                textLines = michael.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.askedMichael = true;
                calculator.SetActive(true);
                RequestManager.inRequestMichael = true;
            }
        }
        if (dialogNum == 3)
        {
            if (neil != null)
            {
                textLines = neil.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.askedNeil = true;
                pencil.SetActive(true);
                RequestManager.inRequestNeil = true;
            }
        }
        if (dialogNum == 4)
        {
            if (serah != null)
            {
                textLines = serah.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.askedSarah = true;
                GameManager.eegeeGet = true;
            }
        }
        if (dialogNum == 5)
        {
            if (teacher != null)
            {
                textLines = teacher.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
            }
        }
        if (dialogNum == 6)
        {
            if (professor2 != null)
            {
                textLines = professor2.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
            }
        }
        if (dialogNum == 7)
        {
            if (michael2 != null)
            {
                textLines = michael2.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.michaelRequestDone = true;
            }
        }
        if (dialogNum == 8)
        {
            if (neil2 != null)
            {
                textLines = neil2.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.neilRequestDone = true;
            }
        }
        if (dialogNum == 9)
        {
            if (michael3 != null)
            {
                textLines = michael3.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
            }
        }
        if (dialogNum == 10)
        {
            if (neil3 != null)
            {
                textLines = neil3.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
            }
        }
        if (dialogNum == 11)
        {
            if (sarah2 != null)
            {
                textLines = sarah2.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.eegeeGet = true;
            }
        }
        if (dialogNum == 12)
        {
            if (teacher2 != null)
            {
                textLines = teacher2.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.testFinished = true;
            }
        }
        if (dialogNum == 13)
        {
            if (meetFBIFloor3 != null)
            {
                textLines = meetFBIFloor3.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;                
            }
        }
        if (dialogNum == 14)
        {
            if (meetFBIFloor1 != null)
            {
                textLines = meetFBIFloor1.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
            }
        }
        if (dialogNum == 15)
        {
            if (intro != null)
            {
                textLines = intro.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
            }
        }
    }
    void EnableDialog()
    {
        dialogPanal.SetActive(true);
        text.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("space"))
        {
            if (currentLine < endLine - 1)
            {
                currentLine++;
                Debug.Log(currentLine);
            }
            else
            {
                Debug.Log(currentLine);
                dialogPanal.SetActive(false);                
                imported = false;
                if (GameManager.dialogMap1 == 5)
                    dialog5End = true;
                if (GameManager.dialogMap1 == 13)
                    GameManager.metFBIFloor3 = false;
                if (GameManager.dialogMap1 == 14)
                    GameManager.metFBIFloor1 = false;
                GameManager.dialogMap1 = 0;
            }
        }
    }
}

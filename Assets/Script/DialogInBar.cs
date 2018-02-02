using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogInBar : MonoBehaviour
{
    public GameObject dialogPanal;
    public GameObject cheatCus;

    public Text text;
    public TextAsset normalCustomer;
    public TextAsset complainCustomer;
    public TextAsset cheatingCustomer;
    public TextAsset boss;
    public TextAsset boss2;
    public TextAsset boss3;

    public string[] textLines;
    int currentLine;
    int endLine;
    bool imported;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InteractionInBar.dialogInBar != 0)
        {
            if (!imported)
                ImportFile(InteractionInBar.dialogInBar);
            EnableDialog();
        }

        if (dialogPanal.activeSelf)
            GameManager.lockPlayer = true;
        else
            GameManager.lockPlayer = false;
    }

    void ImportFile(int dialogNum)
    {
        if (dialogNum == 1)
        {
            if (normalCustomer != null)
            {
                textLines = normalCustomer.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.askedNormalCus = true;
            }
        }
        if (dialogNum == 2)
        {
            if (complainCustomer != null)
            {
                textLines = complainCustomer.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.askedComplainCus = true;
            }
        }
        if (dialogNum == 3)
        {
            if (cheatingCustomer != null)
            {
                textLines = cheatingCustomer.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.askedCheatingCus = true;
                GameManager.cheatDiceGet = true;
            }
        }
        if (dialogNum == 4)
        {
            if (boss != null)
            {
                textLines = boss.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.askedBoss = true;
                GameManager.normalDiceGet = true;
            }
        }
        if (dialogNum == 5)
        {
            if (boss2 != null)
            {
                textLines = boss2.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                
            }
        }
        if (dialogNum == 6)
        {
            if (boss3 != null)
            {
                textLines = boss3.text.Split('\n');
                endLine = textLines.Length;
                currentLine = 0;
                imported = true;
                GameManager.beerGet = true;
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
                
            }
            else
            {
                Debug.Log(InteractionInBar.dialogInBar);
                dialogPanal.SetActive(false);
                imported = false;
                if (InteractionInBar.dialogInBar == 3)
                {
                    cheatCus.SetActive(false);
                }
                
                if (InteractionInBar.dialogInBar == 4)
                {
                    Debug.Log("fight");
                    SceneManager.LoadScene("FightInBar");
                    
                }

                if (InteractionInBar.dialogInBar == 5)
                {
                    Debug.Log("fight again");
                    SceneManager.LoadScene("FightInBar");

                }

                InteractionInBar.dialogInBar = 0;
            }
        }
    }
}

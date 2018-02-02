using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {

    public Text text;
    
    public GameObject win;
    public GameObject lose;
    public GameObject playerAttack;
    public GameObject enermyAttack;
    public GameObject panal;
    public Text textBattle;
    public TextAsset battleText;
    public GameObject dialogPanal;

    string[] textLines;
    int endLine;
    bool imported;
    bool isShowed;
    bool usedCal;
    bool isAttacked;

    public static int enermyHealth = 100;
    public static int playerHealth = 100;
    public static bool turn;
    public static int turnNum;
	// Use this for initialization
/*	void Start () {
        win.SetActive(false);
        lose.SetActive(false);
        turn = false;
        turnNum = 0;
        isAttacked = false;
        isShowed = false;

        dialogPanal.transform.SetAsLastSibling();

        if (battleText != null)
        {
            textLines = battleText.text.Split('\n');
            endLine = textLines.Length;

            imported = true;
        }
    }
*/
    private void OnEnable()
    {
        win.SetActive(false);
        lose.SetActive(false);
        turn = false;
        turnNum = 0;
        isAttacked = false;
        isShowed = false;

        dialogPanal.transform.SetAsLastSibling();

        if (battleText != null)
        {
            textLines = battleText.text.Split('\n');
            endLine = textLines.Length;

            imported = true;
        }
    }

    // Update is called once per frame
    void Update () {
        text.text = "HP: " + playerHealth;
        if (enermyHealth <= 0)
        {
            win.SetActive(true);
        }
        if (playerHealth <= 0)
        {
            lose.SetActive(true);
        }

        if (turn)
        {
            panal.SetActive(true);
            if (dialogPanal.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("space"))
                {

                    if (!isAttacked)
                    {
                        if (!isShowed)
                        {
                            Debug.Log("should use pencil");
                            textBattle.text = textLines[0];
                            isShowed = true;
                        }
                        else
                        {
                            dialogPanal.SetActive(false);
                            isShowed = false;
                        }
                    }
                    else if (isAttacked)
                    {
                        dialogPanal.SetActive(false);
                        isShowed = false;
                        isAttacked = false;
                    }
                }
            }
        }

        if (!turn)
        {
            //panal.SetActive(false);
            enermyAttack.SetActive(true);
        }
       
    }

    public void Escape()
    {
        playerHealth -= 100;
    }



    public void UseCal()
    {
        ShowDialog();
        usedCal = true;
    }

    public void UsePen()
    {
        if (usedCal)
        {
            playerAttack.SetActive(true);
            usedCal = false;
        }
            
    }

    public void ShowDialog()
    {        

        dialogPanal.SetActive(true);
        if (turnNum < endLine)
        {
            textBattle.text = textLines[turnNum - 1];
        }
        
               
    }

    public void Attack()
    {
        if (!isAttacked)
        {
            isAttacked = true;
            dialogPanal.SetActive(true);
            textBattle.text = textLines[4];
            GameObject.Find("Attack").SetActive(false);
        }
        else if (isAttacked)
        {

        }
    }
}

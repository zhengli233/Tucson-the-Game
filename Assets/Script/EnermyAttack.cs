using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnermyAttack : MonoBehaviour {
    public int dialogNum;
    
    public Text text;
    public TextAsset battleText;
    public GameObject dialogPanal;

    string[] textLines;
    int endLine;
    bool imported;

    // Use this for initialization
    void OnEnable () {
        Dialog();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("space"))
        {
            if (BattleController.turnNum == 0)
            {
                BattleController.turnNum++;
                text.text = textLines[BattleController.turnNum];
            }
            else
            {
                gameObject.SetActive(false);
                dialogPanal.SetActive(false);
                BattleController.turn = true;
                BattleController.turnNum++;
            }
                

        }
    }

    public void Dialog()
    {
        if (battleText != null)
        {
            textLines = battleText.text.Split('\n');
            endLine = textLines.Length;

            imported = true;
        }

        dialogPanal.SetActive(true);
        text.text = textLines[BattleController.turnNum];        
    }

    public void ShowAttack()
    {
        gameObject.SetActive(true);
        Invoke("HideAttack", 1f);
    }

    void HideAttack()
    {
        gameObject.SetActive(false);

        BattleController.playerHealth -= 10;

        BattleController.turn = true;
    }
}

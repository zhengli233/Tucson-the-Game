using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightInBarController : MonoBehaviour {

    public GameObject win;
    public GameObject lose;
    public GameObject panel;
    public GameObject dialogPanel;

    public Text healthText;
    public Text text;
    public TextAsset battleText;

    public bool normal;
    public bool cheat;

    bool dice;
    string[] textLines;
    int endLine;
    bool imported;

    // Use this for initialization
    void OnEnable () {
        BattleController.turn = false;
        BattleController.turnNum = 0;
        BattleController.playerHealth = 100;
        BattleController.enermyHealth = 3;
        
        win.SetActive(false);
        lose.SetActive(false);

        dialogPanel.transform.SetAsLastSibling();
        if (battleText != null)
        {
            textLines = battleText.text.Split('\n');
            endLine = textLines.Length;
            text.text = textLines[0];
            dialogPanel.SetActive(true);
            imported = true;
        }

        if (GameManager.currentMap != 0)
            GameManager.previousMap = GameManager.currentMap;
        GameManager.currentMap = 5;
    }
	
	// Update is called once per frame
	void Update () {
//        GameManager.cheatDiceGet = cheat;
//        GameManager.normalDiceGet = normal;

        healthText.text = "HP: " + BattleController.playerHealth;

        if (BattleController.enermyHealth <= 0)
        {
            win.SetActive(true);
            GameManager.winFightInBar = true;
        }
        if (BattleController.playerHealth <= 0)
        {
            lose.SetActive(true);
            GameManager.winFightInBar = false;
        }

        panel.SetActive(true);
        if (dialogPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("space"))
            {
                dialogPanel.SetActive(false);
            }
        }

    }

    public void UseCheatDice()
    {
        dice = true;
        BattleController.enermyHealth--;
        System.Random rnd = new System.Random();
        int num = rnd.Next(1, 5);
        text.text = "Your dice: 6       Dave's dice: " + num;
        dialogPanel.SetActive(true);
        BattleController.turnNum++;
    }

    public void UseNormalDice()
    {
        System.Random rnd = new System.Random();
        int num1 = rnd.Next(1, 6);
        int num2 = rnd.Next(1, 6);
        text.text = "Your dice: " + num1 + "       Dave's dice: " + num2;
        dialogPanel.SetActive(true);
        if (num1 > num2)
        {
            dice = true;
            BattleController.enermyHealth--;
            
            BattleController.turnNum++;
        }
        else
        {
            dice = false;
            BattleController.playerHealth -= 100;
            BattleController.turnNum++; 
        }
            
    }

    
}

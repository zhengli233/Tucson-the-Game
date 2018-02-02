using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightInDowntown : MonoBehaviour {

    public GameObject win;
    public GameObject lose;
    public GameObject playerPanel;
    public GameObject dialogPanel;
    public GameObject enermyAttack;
    public Text text;
    public Text hp;
    public Text attackText;
    public Text armorText;
    //    public TextAsset hint;

    public bool foot;
    public bool baseball;
    public bool helmat;
    public bool beer;

    bool equipedHelmat = false;
    bool usedBeer = false;
    bool turn;
    int turnNum = 0;
    int playerHealth = 100;
    int enermyHealth = 800;
    int attack = 10;
    int armor;
    int defend;

    // Use this for initialization
    void Start()
    {
        turn = true;
        if (GameManager.equipedBaseballBat)
        {
            attack *= 5;
        }
        if (GameManager.equipedBeer)
        {
            attack *= 5;
        }
        if (GameManager.equipedFootballPad)
        {
            armor = 10;
        }
        if (GameManager.equipedHelmat)
        {
            playerHealth = 1000;
        }
    }

    private void OnEnable()
    {
        if (GameManager.currentMap != 0)
            GameManager.previousMap = GameManager.currentMap;
        GameManager.currentMap = 7;
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = "HP: " + playerHealth;
        attackText.text = "Attack: " + attack;
        armorText.text = "Armor: " + armor;

//        GameManager.footballPadGet = foot;
//        GameManager.baseballBatGet = baseball;
//        GameManager.helmatGet = helmat;
//        GameManager.beerGet = beer;

        if (enermyHealth <= 0)
        {
            win.SetActive(true);
            GameManager.fightedFBI = true;
        }
        if (playerHealth <= 0)
        {
            lose.SetActive(true);
        }

        if (dialogPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("space"))
            {
                dialogPanel.SetActive(false);
            }
        }

        if (turn)
        {
            playerPanel.SetActive(true);            
        }
        if (!turn)
        {
            playerPanel.SetActive(false);
            if (turnNum == 1)
            {
                enermyAttack.SetActive(true);                
            }
            if (turnNum == 2)
            {
                text.text = "Enermy waves his weapen. A strong attack is coming!";
                dialogPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("space"))
                {
                    dialogPanel.SetActive(false);
                    turn = true;                    
                }                
            }
            if (turnNum == 3)
            {
                enermyAttack.SetActive(true);
                playerHealth -= 500 - defend;
                turnNum = 0;
            }
        }
    }

    public void UseFootballPad()
    {
        armor = 10;
    }

    public void UseBaseballBat()
    {
        attack *= 5;
    }

    public void UseHelmat()
    {
        if (!equipedHelmat)
        {
            playerHealth += 900;
            equipedHelmat = true;
        }

    }

    public void UseBeer()
    {
        if (!usedBeer)
        {
            usedBeer = true;
            attack *= 5;
        }
    }

    public void Attack()
    {
        enermyHealth -= attack;
        turn = false;
        turnNum ++;
    }

    public void EnermyAttack()
    {
        playerHealth -= 4 * (100 - armor - defend/10);
        defend = 0;
        turn = true;        
    }

    public void Defend()
    {
        defend = 500;
        turnNum++;
        turn = false;
    }
}

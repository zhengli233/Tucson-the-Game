using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightInSS : MonoBehaviour {

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
    int playerHealth = 100;
    int enermyHealth = 500;
    int attack = 10;
    int armor;

	// Use this for initialization
	void Start () {
        turn = true;
        text.text = "Hint: use all the items you collected in the sports store before you attack!";
        dialogPanel.SetActive(true);
	}

    private void OnEnable()
    {
        if (GameManager.currentMap != 0)
            GameManager.previousMap = GameManager.currentMap;
        GameManager.currentMap = 6;
    }

    // Update is called once per frame
    void Update () {
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
            GameManager.winFightInSS = true;
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
            enermyAttack.SetActive(true);
        }
    }

    public void UseFootballPad()
    {
        armor = 10;
        GameManager.footballPadGet = false;
        GameManager.equipedFootballPad = true;
    }

    public void UseBaseballBat()
    {
        attack *= 5;
        GameManager.baseballBatGet = false;
        GameManager.equipedBaseballBat = true;
    }

    public void UseHelmat()
    {
        if (!equipedHelmat)
        {
            playerHealth += 900;
            equipedHelmat = true;
        }
        GameManager.helmatGet = false;
        GameManager.equipedHelmat = true;
    }

    public void UseBeer()
    {
        if (!usedBeer)
        {
            usedBeer = true;
            attack *= 5;
        }
        GameManager.beerGet = false;
        GameManager.equipedBeer = true;
    }

    public void Attack()
    {
        enermyHealth -= attack;
        turn = false;
    }

    public void EnermyAttack()
    {
        playerHealth -= 4 * (100 - armor);
        turn = true;
    }
}

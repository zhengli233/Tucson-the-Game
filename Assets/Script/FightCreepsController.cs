using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightCreepsController : MonoBehaviour {

    public GameObject win;
    public GameObject lose;
    public GameObject playerPanel;
    public GameObject dialogPanel;
    public GameObject enemyAttack;
    public GameObject alien1;
    public GameObject alien2;
    public GameObject alien3;
    public GameObject alien4;
    public Text text;
    public Text hp;
    public Text attackText;
    public Text armorText;

    public int showEnemyHP;

    bool turn = true;
    int turnNum = 0;
    int playerHealth = 100;
    int enemyHealth = 1500;
    int attack = 10;
    int armor = 0;
    int defend = 0;

    int shield = 0;
    int enemyDefend = 0;
    bool shielded;

    // Use this for initialization
    void Start () {
        
    }

    private void OnEnable()
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

        if (GameManager.currentMap != 0)
            GameManager.previousMap = GameManager.currentMap;
        GameManager.currentMap = 10;
        if (MazeController.whichAlien == 1)
            alien1.SetActive(true);
        if (MazeController.whichAlien == 2)
            alien2.SetActive(true);
        if (MazeController.whichAlien == 3)
            alien3.SetActive(true);
        if (MazeController.whichAlien == 4)
            alien4.SetActive(true);

    }

    // Update is called once per frame
    void Update () {
        showEnemyHP = enemyHealth;

        hp.text = "HP: " + playerHealth;
        attackText.text = "Attack: " + attack;
        armorText.text = "Armor: " + armor;

        if (turn)
        {
            playerPanel.SetActive(true);

        }
        if (!turn)
        {
            if (MazeController.whichAlien == 1 || MazeController.whichAlien == 3)
            {
                if (enemyHealth < 600)
                {
                    if (enemyDefend == 0)
                    {
                        text.text = "Alien increases its armor";
                        dialogPanel.SetActive(true);
                        enemyDefend = 250;
                        turn = true;
                    }
                    else
                        enemyAttack.SetActive(true);
                }
                else
                {
                    enemyAttack.SetActive(true);
                }
            }
            if (MazeController.whichAlien == 2 || MazeController.whichAlien == 4)
            {
                if (enemyHealth < 600)
                {
                    if (shield == 0 && !shielded)
                    {
                        text.text = "A shield starts to protect the alien. The shield can block 3 times of your attack.";
                        dialogPanel.SetActive(true);
                        shield = 2;
                        shielded = true;
                        turn = true;
                    }
                    else
                        enemyAttack.SetActive(true);
                }
                else
                    enemyAttack.SetActive(true);
            }
            
        }
        if (dialogPanel.activeSelf)
        {
            playerPanel.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("space"))
            {
                dialogPanel.SetActive(false);
                playerPanel.SetActive(true);
            }
        }

        if (playerHealth <= 0)
        {
            lose.SetActive(true);
        }
        if (enemyHealth <= 0)
        {
            win.SetActive(true);
        }
    }

    public void EnemyAttack()
    {
        playerHealth -= 3 * (100 - armor - defend / 10);
        turn = true;
    }

    public void PlayerAttack()
    {

        turn = false;
    }

    public void StrongAttack()
    {
        if(shield <= 0)
            enemyHealth -= attack * 2 - enemyDefend;
        if (shield > 0)
        {
            shield -= 1;
            text.text = "Alien's shield blocks your attack";
        }
        turn = false;
    }

    public void QuickAttack()
    {
        if (shield <= 0)
        {
            if (enemyDefend == 0)
            {
                enemyHealth -= attack * 2;
            }
        }
        if (shield > 0)
        {
            text.text = "Your Quick Attacks break the shield";
            dialogPanel.SetActive(true);
            enemyHealth -= 340;
            shield = 0;
        }
        turn = false;
    }

    public void Defend()
    {

        turn = false;
    }
}

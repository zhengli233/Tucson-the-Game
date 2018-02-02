using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightInMaze : MonoBehaviour {

    public GameObject win;
    public GameObject lose;
    public GameObject playerPanel;
    public GameObject dialogPanel;
    public GameObject enermyAttack;
    public GameObject rayGunAttack;
    public GameObject strong;
    public GameObject quick;
    public GameObject def;
    public Text text;
    public Text hp;
    public Text attackText;
    public Text armorText;
    //    public TextAsset hint;

    public bool foot;
    public bool baseball;
    public bool helmat;
    public bool beer;

    bool usedEegee;
    bool mindControlled = false;

    bool equipedHelmat = false;
    bool usedBeer = false;
    public static bool turn;
    int turnNum = 0;
    int playerHealth = 100;
    int enemyHealth = 3000;
    int attack = 10;
    int armor = 0;

    int debuff = 0;
    int debuffTurn = 0;
    int defend = 0;
    int shield = 0;
    int enemyDefend = 0;

    // Use this for initialization
    void Start()
    {
        turn = true;
        /*        GameManager.footballPadGet = foot;
                GameManager.baseballBatGet = baseball;
                GameManager.helmatGet = helmat;
                GameManager.beerGet = beer;*/
//        GameManager.eegeeGet = true;
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
            armor = 20;
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
        GameManager.currentMap = 9;
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = "HP: " + playerHealth;
        attackText.text = "Attack: " + attack;
        armorText.text = "Armor: " + armor;

        if (debuffTurn == 0)
        {
            debuff = 0;
        }

        
        if (enemyHealth <= 0)
        {
            win.SetActive(true);
//            InteractionInSS.winFight = true;
        }
        if (playerHealth <= 0)
        {
            lose.SetActive(true);

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

        if (turn && !dialogPanel.activeSelf)
        {
            playerPanel.SetActive(true);
            if (debuff == 0)
            {
                strong.SetActive(true);
                quick.SetActive(true);
                def.SetActive(true);
            }
            if (debuff == 1)
            {
                def.SetActive(true);
            }
            if (debuff == 2)
            {
                strong.SetActive(true);
                quick.SetActive(true);
            }
        }
        if (!turn)
        {            
            playerPanel.SetActive(false);

            if (turnNum == 0)
            {
                if (enemyHealth > 500)
                {
                    if (debuff != 0)
                    {
                        System.Random rnd = new System.Random();
                        int alienAttack = rnd.Next(1, 2);

                        if (alienAttack == 1)
                        {
                            enermyAttack.SetActive(true);
                        }
                        if (alienAttack == 2)
                        {
                            text.text = "Alien commander aims its ray gun at you!";
                            dialogPanel.SetActive(true);
                            turnNum = 1;
                            turn = true;
                        }

                    }
                    if (debuff == 0)
                    {
                        System.Random rnd = new System.Random();
                        int num = rnd.Next(1, 3);

                        if (num == 1)
                        {
                            text.text = "Alien commander uses fronzen lazer. You can't attack for 2 round.";
                            dialogPanel.SetActive(true);
                            strong.SetActive(false);
                            quick.SetActive(false);
                            debuffTurn = 2;
                            debuff = 1;
                            turn = true;
                        }

                        if (num == 2)
                        {
                            text.text = "Alien commander uses stun rod. You can't defend for 2 round.";
                            dialogPanel.SetActive(true);
                            def.SetActive(false);
                            debuffTurn = 2;
                            debuff = 2;
                            turn = true;
                        }

                        if (num == 3)
                        {
                            text.text = "Alien commander aims its ray gun at you!";
                            dialogPanel.SetActive(true);
                            turnNum = 1;
                            turn = true;
                        }
                    }
                }
                else
                {
                    if (!mindControlled && !usedEegee)
                    {
                        text.text = "Alien Commander uses Mind Control to you. You feel headache and can't attack or denfend!";
                        dialogPanel.SetActive(true);

                        MindControl();
                    }
                    if (mindControlled)
                    {
                        enermyAttack.SetActive(true);                        
                    }
                    if (usedEegee)
                    {
                        enermyAttack.SetActive(true);
                    }
                }
            }
            if (turnNum == 1)
            {
                AttackPlayer();
            }
                        

        }
    }

    

    public void Defend()
    {
        if (debuffTurn > 0)
        {
            debuffTurn--;
        }
        defend = 600;
        turn = false;
    }

    public void StrongAttack()
    {
        if (debuffTurn > 0)
        {
            debuffTurn--;
        }
        if (shield <= 0)
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
        if (debuffTurn > 0)
        {
            debuffTurn--;
        }
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

    public void AttackPlayer()
    {
        playerHealth -= 800 - defend;
        turnNum = 0;
        defend = 0;
        turn = true;
    }

    public void EnemyAttack()
    {
        
        playerHealth -= 5 * (70 - armor) - defend/3;
        defend = 0;
        turn = true;       
    }

    public void MindControl()
    {
        mindControlled = true;
        turn = true;
    }

    

    public void UseEegee()
    {
        mindControlled = false;
        text.text = "Use Eegee's. You are released from Mind Contorl";
        dialogPanel.SetActive(true);
        
    }

    
}

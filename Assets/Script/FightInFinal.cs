using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FightInFinal : MonoBehaviour {

    public GameObject win;
    public GameObject lose;
    public GameObject playerPanel;
    public GameObject dialogPanel;
    public GameObject enermyAttack;
    public Text text;
    public Text hp;
    public Text attackText;
    public Text armorText;

    bool turn = true;
    int turnNum = 0;
    int playerHealth = 100;
    int enermyHealth = 800;
    int attack = 10;
    int armor;
    int defend;

    // Use this for initialization
    void Start () {
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
        GameManager.currentMap = 11;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void UseRayGun()
    {

    }
}

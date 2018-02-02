using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartNewGame()
    {
        GameManager.currentMap = 0;
        GameManager.previousMap = 0;
        GameManager.floor = 4;
        GameManager.askedMichael = false;
        GameManager.askedNeil = false;
        GameManager.askedProf = false;
        GameManager.calculatorGet = false;
        GameManager.pencilGet = false;
        GameManager.dialogMap1 = 0;
       
        GameManager.michaelRequestDone = false;
        GameManager.neilRequestDone = false;
        GameManager.askedSarah = false;
        GameManager.eegeeGet = false;
        GameManager.testFinished = false;
        GameManager.fromPaperBattle = false;
        GameManager.metFBIFloor1 = false;
        GameManager.metFBIFloor3 = false;
        GameManager.lockPlayer = false;
        GameManager.cheatDiceGet = false;
        GameManager.normalDiceGet = false;
        GameManager.beerGet = false;
        GameManager.footballPadGet = false;
        GameManager.baseballBatGet = false;
        GameManager.helmatGet = false;
        GameManager.winFightInSS = false;
        GameManager.askedSarahInSS = false;
        GameManager.askedCrazyCusInSS = false;
        GameManager.showFBI = false;
        GameManager.fightedFBI = false;
        GameManager.askedNormalCus = false;
        GameManager.askedComplainCus = false;
        GameManager.askedCheatingCus = false;
        GameManager.askedBoss = false;
        GameManager.winFightInBar = false;
        GameManager.equipedBeer = false;
        GameManager.equipedFootballPad = false;
        GameManager.equipedBaseballBat = false;
        GameManager.equipedHelmat = false;
        GameManager.mazeMapGet = false;
        GameManager.fightedAlien = false;
        GameManager.rayGunGet = false;
        GameManager.fightedProfessor = false;
        SceneManager.LoadScene("Map1");
    }
}

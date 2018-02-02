using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Save : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveInfo()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "playerInfo.dat", FileMode.OpenOrCreate);

        PlayerData data = new PlayerData();
        data.currentMap = GameManager.currentMap;
        data.previousMap = GameManager.previousMap;
        data.floor = GameManager.floor;
        data.askedMichael = GameManager.askedMichael;
        data.askedNeil = GameManager.askedNeil;
        data.askedProf = GameManager.askedProf;
        data.calculatorGet = GameManager.calculatorGet;
        data.pencilGet = GameManager.pencilGet;
        data.dialogMap1 = GameManager.dialogMap1;
        data.posX = player.transform.position.x;
        data.posY = player.transform.position.y;
        data.michaelRequestDone = GameManager.michaelRequestDone;
        data.neilRequestDone = GameManager.neilRequestDone;
        data.askedSarah = GameManager.askedSarah;
        data.eegeeGet = GameManager.eegeeGet;
        data.testFinished = GameManager.testFinished;
        data.fromPaperBattle = GameManager.fromPaperBattle;
        data.metFBIFloor1 = GameManager.metFBIFloor1;
        data.metFBIFloor3 = GameManager.metFBIFloor3;
        data.lockPlayer = GameManager.lockPlayer;
        data.cheatDiceGet = GameManager.cheatDiceGet;
        data.normalDiceGet = GameManager.normalDiceGet;
        data.beerGet = GameManager.beerGet;
        data.footballPadGet = GameManager.footballPadGet;
        data.baseballBatGet = GameManager.baseballBatGet;
        data.helmatGet = GameManager.helmatGet;
        data.winFightInSS = GameManager.winFightInSS;
        data.askedSarahInSS = GameManager.askedSarahInSS;
        data.askedCrazyCusInSS = GameManager.askedCrazyCusInSS;
        data.showFBI = GameManager.showFBI;
        data.fightedFBI = GameManager.fightedFBI;
        data.askedNormalCus = GameManager.askedNormalCus;
        data.askedComplainCus = GameManager.askedComplainCus;
        data.askedCheatingCus = GameManager.askedCheatingCus;
        data.askedBoss = GameManager.askedBoss;
        data.winFightInBar = GameManager.winFightInBar;
        data.equipedBeer = GameManager.equipedBeer;
        data.equipedFootballPad = GameManager.equipedFootballPad;
        data.equipedBaseballBat = GameManager.equipedBaseballBat;
        data.equipedHelmat = GameManager.equipedHelmat;
        data.mazeMapGet = GameManager.mazeMapGet;
        data.fightedAlien = GameManager.fightedAlien;
        data.rayGunGet = GameManager.rayGunGet;
        data.fightedProfessor = GameManager.fightedProfessor;

        bf.Serialize(file, data);
        file.Close();
    }
}

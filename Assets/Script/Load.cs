using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadInfo()
    {
        Vector2 playerPosition;
        if (GameObject.Find("Player"))
            player = GameObject.Find("Player");
        if (File.Exists(Application.persistentDataPath + "playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            GameManager.currentMap = data.currentMap;
            GameManager.previousMap = data.previousMap;
            GameManager.floor = data.floor;
            GameManager.askedMichael = data.askedMichael;
            GameManager.askedNeil = data.askedNeil;
            GameManager.askedProf = data.askedProf;
            GameManager.calculatorGet = data.calculatorGet;
            GameManager.pencilGet = data.pencilGet;
            GameManager.dialogMap1 = data.dialogMap1;
/*            playerPosition.x = data.posX;
            playerPosition.y = data.posY;
            player.transform.position = playerPosition;*/
            GameManager.michaelRequestDone = data.michaelRequestDone;
            GameManager.neilRequestDone = data.neilRequestDone;
            GameManager.askedSarah = data.askedSarah;
            GameManager.eegeeGet = data.eegeeGet;
            GameManager.testFinished = data.testFinished;
            GameManager.fromPaperBattle = data.fromPaperBattle;
            GameManager.metFBIFloor1 = data.metFBIFloor1;
            GameManager.metFBIFloor3 = data.metFBIFloor3;
            GameManager.lockPlayer = data.lockPlayer;
            GameManager.cheatDiceGet = data.cheatDiceGet;
            GameManager.normalDiceGet = data.normalDiceGet;
            GameManager.beerGet = data.beerGet;
            GameManager.footballPadGet = data.footballPadGet;
            GameManager.baseballBatGet = data.baseballBatGet;
            GameManager.helmatGet = data.helmatGet;
            GameManager.winFightInSS = data.winFightInSS;
            GameManager.askedSarahInSS = data.askedSarahInSS;
            GameManager.askedCrazyCusInSS = data.askedCrazyCusInSS;
            GameManager.showFBI = data.showFBI;
            GameManager.fightedFBI = data.fightedFBI;
            GameManager.askedNormalCus = data.askedNormalCus;
            GameManager.askedComplainCus = data.askedComplainCus;
            GameManager.askedCheatingCus = data.askedCheatingCus;
            GameManager.askedBoss = data.askedBoss;
            GameManager.winFightInBar = data.winFightInBar;
            GameManager.equipedBeer = data.equipedBeer;
            GameManager.equipedFootballPad = data.equipedFootballPad;
            GameManager.equipedBaseballBat = data.equipedBaseballBat;
            GameManager.equipedHelmat = data.equipedHelmat;
            GameManager.mazeMapGet = data.mazeMapGet;
            GameManager.fightedAlien = data.fightedAlien;
            GameManager.rayGunGet = data.rayGunGet;
            GameManager.fightedProfessor = data.fightedProfessor;

            GameManager.fromLoad = true;

            if (GameManager.currentMap == 1)
            {
                Debug.Log("to map1");
                SceneManager.LoadScene("Map1");
            }

            if (GameManager.currentMap == 2)
            {
                SceneManager.LoadScene("Downtown");
            }

            if (GameManager.currentMap == 3)
            {
                SceneManager.LoadScene("Bar");
            }

            if (GameManager.currentMap == 4)
            {
                SceneManager.LoadScene("SportsStore");
            }

            if (GameManager.currentMap == 8)
            {
                SceneManager.LoadScene("Maze");
            }

            if (GameManager.currentMap == 9)
            {
                SceneManager.LoadScene("Final");
            }
        }
        else
            SceneManager.LoadScene("Map1");
    }
}

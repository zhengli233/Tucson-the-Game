using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {
    public static GameManager gameManagerControl;

    public static Vector2 fromSSToDowntown;
    public static Vector2 fromBarToDowntown;
    public static Vector2 fromBattleInDowntown;

    public static bool lockPlayer;
    public static bool initMaze;
    public static int[] route = new int[10];

    public static bool fromLoad;
    public static int currentMap = 0;
    public static int previousMap = 0;
    public static bool enterUpDoor;
    public static int floor;
    public static int dialogMap1;
    public static bool fightScene;
    public static bool askedProf;
    public static bool askedMichael;
    public static bool michaelRequestDone;
    public static bool askedNeil;
    public static bool neilRequestDone;
    public static bool askedSarah;
    public static bool calculatorGet;
    public static bool pencilGet;
    public static bool eegeeGet;
    public static bool testFinished;
    public static bool fromPaperBattle;
    public static bool metFBIFloor3;
    public static bool metFBIFloor1;
    public static bool cheatDiceGet;
    public static bool normalDiceGet;
    public static bool beerGet;
    public static bool footballPadGet;
    public static bool baseballBatGet;
    public static bool helmatGet;
    public static bool askedSarahInSS;
    public static bool askedCrazyCusInSS;
    public static bool winFightInSS;
    public static bool showFBI;
    public static bool fightedFBI;
    public static bool askedNormalCus;
    public static bool askedComplainCus;
    public static bool askedCheatingCus;
    public static bool askedBoss;
    public static bool winFightInBar;
    public static bool equipedBeer;
    public static bool equipedFootballPad;
    public static bool equipedBaseballBat;
    public static bool equipedHelmat;
    public static bool mazeMapGet;
    public static bool fightedAlien;
    public static bool rayGunGet;
    public static bool fightedProfessor;

    public GameObject professor;
    public GameObject player;
    public GameObject michael;
    public GameObject neil;
    public GameObject serah;
    public GameObject teacher;
    public Text floorText;
    public GameObject floorImage;
    public GameObject calculator;
    public GameObject pencil;
    public GameObject get;
    public Text getText;

    public int dialogNumber;
    public int showFloor;
    public bool getCal;
    public bool getPen;
    public static bool isIntroducted;

/*    private void Awake()
    {
        if (gameManagerControl == null)
        {
            DontDestroyOnLoad(gameObject);
            gameManagerControl = this;
        }
        else if (gameManagerControl != this)
        {
            Destroy(gameObject);
        }
    }
*/
    // Use this for initialization
    void Start () {
        dialogMap1 = 0;
        fightScene = false;
        calculatorGet = false;
        pencilGet = false;
        lockPlayer = false;
        pencil.SetActive(false);
        calculator.SetActive(false);

        fromSSToDowntown.x = 0.18f;
        fromSSToDowntown.y = 12.62f;
        fromBarToDowntown.x = -5.92f;
        fromBarToDowntown.y = 12.62f;
        fromBattleInDowntown.x = -6;
        fromBattleInDowntown.y = 7.12f;
        if (!isIntroducted)
        {
            dialogMap1 = 15;
            isIntroducted = true;
        }
        
    }

    private void OnEnable()
    {
        if (currentMap != 0)
            previousMap = currentMap;
        currentMap = 1;
        if (fromLoad)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            Vector2 playerPosition;
            playerPosition.x = data.posX;
            playerPosition.y = data.posY;
            player.transform.position = playerPosition;
            fromLoad = false;
        }
    }

    // Update is called once per frame
    void Update () {
//        calculatorGet = getCal;
//        pencilGet = getPen;

        if (Mathf.Abs(player.transform.position.y - 2.77f) < 0.3)
            floor = 4;
        if (Mathf.Abs(player.transform.position.y - 0.82f) < 0.3)
            floor = 3;
        if (Mathf.Abs(player.transform.position.y + 1.13f) < 0.3)
            floor = 2;
        if (Mathf.Abs(player.transform.position.y + 3.08f) < 0.3)
            floor = 1;
        showFloor = floor;
        if (Mathf.Abs(player.transform.position.x - professor.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y - professor.transform.position.y) < 0.2)
        {
            Debug.Log("close to professor");
            if (Input.GetKey("e"))
            {
                if (!askedProf)
                    dialogMap1 = 1;
                else
                    dialogMap1 = 6;
            }
        }
        if (Mathf.Abs(player.transform.position.x - michael.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y - michael.transform.position.y) < 0.2)
        {
            Debug.Log("close to michael");
            if (Input.GetKey("e"))
            {
                if (!calculatorGet)
                {
                    if (!askedMichael)
                        dialogMap1 = 2;
                    else
                        dialogMap1 = 9;
                }
                    
                else
                    dialogMap1 = 7;
            }
        }
        if (Mathf.Abs(player.transform.position.x - neil.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y - neil.transform.position.y) < 0.2)
        {
            
            if (Input.GetKey("e"))
            {
                if (!pencilGet)
                {
                    if (!askedNeil)
                        dialogMap1 = 3;
                    else
                        dialogMap1 = 10;
                } 
                else
                    dialogMap1 = 8;
            }
        }
        if (Mathf.Abs(player.transform.position.x - serah.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y - serah.transform.position.y) < 0.2)
        {
            Debug.Log("close to sarah");
            if (Input.GetKey("e"))
            {
                if (!askedSarah)
                    dialogMap1 = 4;
                else
                    dialogMap1 = 11;
            }
        }
        if (Mathf.Abs(player.transform.position.x - teacher.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y - teacher.transform.position.y) < 0.2)
        {
            
            if (Input.GetKey("e"))
            {
                if (!ToMap1.fromMap2)
                    dialogMap1 = 5;
                else
                    dialogMap1 = 12;
            }
        }

        dialogNumber = dialogMap1;

        if (Mathf.Abs(player.transform.position.x - calculator.transform.position.x) < 0.2 && Mathf.Abs(player.transform.position.y - calculator.transform.position.y) < 0.2)
        {
            if (calculator.activeSelf)
            {
                if (Input.GetKey("e"))
                {
                    calculator.SetActive(false);
                    calculatorGet = true;
                    RequestManager.inRequestMichael = false;
                    getText.text = "Get CALCULATOR!";
                    get.SetActive(true);
                    Invoke("HideGetImage", 2f);
                    
                }
            }
               

        }
        if (Mathf.Abs(player.transform.position.x - pencil.transform.position.x) < 0.2 && Mathf.Abs(player.transform.position.y - pencil.transform.position.y) < 0.2)
        {
            if (pencil.activeSelf)
            {
                if (Input.GetKey("e"))
                {
                    pencil.SetActive(false);
                    pencilGet = true;
                    RequestManager.inRequestNeil = false;
                    getText.text = "Get PENCIL!";
                    get.SetActive(true);
                    Invoke("HideGetImage", 2f);
                    
                }
            }
            

        }

        if (metFBIFloor3)
        {
            dialogMap1 = 13;
        }

        if (metFBIFloor1)
        {
            dialogMap1 = 14;
        }

        if (fightScene)
        {
            SceneManager.LoadScene("Fight");
        }

        if (Player.goInDoor)
        {
            ShowFloorNum();
        }

        if (ToMap1.fromMap2)
        {
            if (Mathf.Abs(player.transform.position.x + 4.63f) < 0.2f && Mathf.Abs(player.transform.position.y + 2.89f) < 0.2f)
            {
                SceneManager.LoadScene("Downtown");
            }
        }
    }

    void ShowFloorNum()
    {
        floorText.text = "Floor" + floor;
        floorImage.SetActive(true);
        Invoke("HideFloorImage", 2f);
    }

    void HideFloorImage()
    {
        floorImage.SetActive(false);
        Player.goInDoor = false;
    }

    void HideGetImage()
    {
        get.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "playerInfo.dat", FileMode.OpenOrCreate);

        PlayerData data = new PlayerData();
        data.currentMap = currentMap;
        data.previousMap = previousMap;
        data.floor = floor;
        data.askedMichael = askedMichael;
        data.askedNeil = askedNeil;
        data.askedProf = askedProf;
        data.calculatorGet = calculatorGet;
        data.pencilGet = pencilGet;
        data.dialogMap1 = dialogMap1;
        data.posX = player.transform.position.x;
        data.posY = player.transform.position.y;
        data.michaelRequestDone = michaelRequestDone;
        data.neilRequestDone = neilRequestDone;
        data.askedSarah = askedSarah;
        data.eegeeGet = eegeeGet;
        data.testFinished = testFinished;
        data.fromPaperBattle = fromPaperBattle;
        data.metFBIFloor1 = metFBIFloor1;
        data.metFBIFloor3 = metFBIFloor3;
        data.lockPlayer = lockPlayer;
        data.cheatDiceGet = cheatDiceGet;
        data.normalDiceGet = normalDiceGet;
        data.beerGet = beerGet;
        data.footballPadGet = footballPadGet;
        data.baseballBatGet = baseballBatGet;
        data.helmatGet = helmatGet;
        data.winFightInSS = winFightInSS;
        data.askedSarahInSS = askedSarahInSS;
        data.askedCrazyCusInSS = askedCrazyCusInSS;
        data.showFBI = showFBI;
        data.fightedFBI = fightedFBI;
        data.askedNormalCus = askedNormalCus;
        data.askedComplainCus = askedComplainCus;
        data.askedCheatingCus = askedCheatingCus;
        data.askedBoss = askedBoss;
        data.winFightInBar = winFightInBar;
        data.equipedBeer = equipedBeer;
        data.equipedFootballPad = equipedFootballPad;
        data.equipedBaseballBat = equipedBaseballBat;
        data.equipedHelmat = equipedHelmat;
        data.mazeMapGet = mazeMapGet;
        data.fightedAlien = fightedAlien;
        data.rayGunGet = rayGunGet;
        data.fightedProfessor = fightedProfessor;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        Vector2 playerPosition;
        if (File.Exists(Application.persistentDataPath + "playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            currentMap = data.currentMap;
            previousMap = data.previousMap;
            floor = data.floor;
            askedMichael = data.askedMichael;
            askedNeil = data.askedNeil;
            askedProf = data.askedProf;
            calculatorGet = data.calculatorGet;
            pencilGet = data.pencilGet;
            dialogMap1 = data.dialogMap1;
            playerPosition.x = data.posX;
            playerPosition.y = data.posY;
            player.transform.position = playerPosition;
            michaelRequestDone = data.michaelRequestDone;
            neilRequestDone = data.neilRequestDone;
            askedSarah = data.askedSarah;
            eegeeGet = data.eegeeGet;
            testFinished = data.testFinished;
            fromPaperBattle = data.fromPaperBattle;
            metFBIFloor1 = data.metFBIFloor1;
            metFBIFloor3 = data.metFBIFloor3;
            lockPlayer = data.lockPlayer;
            cheatDiceGet = data.cheatDiceGet;
            normalDiceGet = data.normalDiceGet;
            beerGet = data.beerGet;
            footballPadGet = data.footballPadGet;
            baseballBatGet = data.baseballBatGet;
            helmatGet = data.helmatGet;
            winFightInSS = data.winFightInSS;
            askedSarahInSS = data.askedSarahInSS;
            askedCrazyCusInSS = data.askedCrazyCusInSS;
            showFBI = data.showFBI;
            fightedFBI = data.fightedFBI;
            askedNormalCus = data.askedNormalCus;
            askedComplainCus = data.askedComplainCus;
            askedCheatingCus = data.askedCheatingCus;
            askedBoss = data.askedBoss;
            winFightInBar = data.winFightInBar;
            equipedBeer = data.equipedBeer;
            equipedFootballPad = data.equipedFootballPad;
            equipedBaseballBat = data.equipedBaseballBat;
            equipedHelmat = data.equipedHelmat;
            mazeMapGet = data.mazeMapGet;
            fightedAlien = data.fightedAlien;
            rayGunGet = data.rayGunGet;
            fightedProfessor = data.fightedProfessor;

            GameManager.fromLoad = true;

            if (GameManager.currentMap == 1)
            {
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

    }
}

[Serializable]
public class PlayerData
{
    public float posX;
    public float posY;
    public int money;

    
    public int floor;
    public int dialogMap1;
    public int previousMap;
    public int currentMap;
    
    public bool askedProf;
    public bool askedMichael;
    public bool michaelRequestDone;
    public bool askedNeil;
    public bool neilRequestDone;
    public bool askedSarah;
    public bool calculatorGet;
    public bool pencilGet;
    public bool eegeeGet;
    public bool testFinished;
    public bool fromPaperBattle;
    public bool metFBIFloor3;
    public bool metFBIFloor1;
    public bool lockPlayer;
    public bool cheatDiceGet;
    public bool normalDiceGet;
    public bool beerGet;
    public bool footballPadGet;
    public bool baseballBatGet;
    public bool helmatGet;
    public bool askedSarahInSS;
    public bool askedCrazyCusInSS;
    public bool winFightInSS;
    public bool showFBI;
    public bool fightedFBI;
    public bool askedNormalCus;
    public bool askedComplainCus;
    public bool askedCheatingCus;
    public bool askedBoss;
    public bool winFightInBar;
    public bool equipedBeer;
    public bool equipedFootballPad;
    public bool equipedBaseballBat;
    public bool equipedHelmat;
    public bool mazeMapGet;
    public bool fightedAlien;
    public bool rayGunGet;
    public bool fightedProfessor;
}
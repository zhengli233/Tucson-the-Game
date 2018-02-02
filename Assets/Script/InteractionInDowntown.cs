using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class InteractionInDowntown : MonoBehaviour {

    
    

    public GameObject player;
    public GameObject FBI;
    public GameObject cabby;
    public GameObject dialogPanel;
    public GameObject get;
    public Text text;
    public Text getText;
    public TextAsset FBIText;
    public TextAsset FBIText2;
    public TextAsset cabbyText;

    public bool FBIShow;

    public string[] textLines;
    int currentLine;
    int endLine;
    bool imported;

    // Use this for initialization
    void Start () {
        FBI.SetActive(false);
        cabby.SetActive(false);
	}

    private void OnEnable()
    {
        if (GameManager.currentMap != 0)
            GameManager.previousMap = GameManager.currentMap;
        GameManager.currentMap = 2;

        GameManager.fromSSToDowntown.x = 0.18f;
        GameManager.fromSSToDowntown.y = 12.62f;
        GameManager.fromBarToDowntown.x = -5.92f;
        GameManager.fromBarToDowntown.y = 12.62f;
        GameManager.fromBattleInDowntown.x = -6;
        GameManager.fromBattleInDowntown.y = 7.12f;
        if (GameManager.previousMap == 3)
        {
            player.transform.position = GameManager.fromBarToDowntown;
        }

        if (GameManager.previousMap == 4)
        {
            player.transform.position = GameManager.fromSSToDowntown;
        }

        if (GameManager.previousMap == 7)
        {
            player.transform.position = GameManager.fromBattleInDowntown;
            getText.text = "Acquire skills: Strong Attack & Quick Attack";
            get.SetActive(true);
            Invoke("HideGet", 2f);
        }

        if (GameManager.fromLoad)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            Vector2 playerPosition;
            playerPosition.x = data.posX;
            playerPosition.y = data.posY;
            player.transform.position = playerPosition;
            GameManager.fromLoad = false;
        }
    }

    // Update is called once per frame
    void Update () {

        if (dialogPanel.activeSelf)
            GameManager.lockPlayer = true;
        else
            GameManager.lockPlayer = false;

        //        GameManager.showFBI = FBIShow;
        if (Mathf.Abs(player.transform.position.x + 5.9f) < 0.5 && Mathf.Abs(player.transform.position.y -12.872f) < 0.1)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                SceneManager.LoadScene("Bar");
            }
        }

        if (Mathf.Abs(player.transform.position.x - 0.165f) < 0.5 && Mathf.Abs(player.transform.position.y - 13.188f) < 0.1)
        {
            if (GameManager.beerGet)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    SceneManager.LoadScene("SportsStore");
                }
            }            
        }

        if (Mathf.Abs(player.transform.position.x - FBI.transform.position.x) < 0.3 && Mathf.Abs(player.transform.position.y - FBI.transform.position.y) < 0.3f)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!GameManager.fightedFBI)
                {
                    if (FBIText != null)
                    {
                        textLines = FBIText.text.Split('\n');
                        endLine = textLines.Length;
                        currentLine = 0;
                        imported = true;
                        text.text = textLines[currentLine];
                        dialogPanel.SetActive(true);
                    }
                }
                else
                {
                    if (FBIText2 != null)
                    {
                        textLines = FBIText2.text.Split('\n');
                        endLine = textLines.Length;
                        currentLine = 0;
                        imported = true;
                        text.text = textLines[currentLine];
                        dialogPanel.SetActive(true);
                    }
                }

            }

        }
        if (Mathf.Abs(player.transform.position.x - cabby.transform.position.x) < 0.3 && Mathf.Abs(player.transform.position.y - cabby.transform.position.y) < 0.3f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (cabbyText != null)
                {
                    textLines = cabbyText.text.Split('\n');
                    endLine = textLines.Length;
                    currentLine = 0;
                    imported = true;
                    text.text = textLines[currentLine];
                    dialogPanel.SetActive(true);
                }
            }
        }
        if (dialogPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("space"))
            {

                if (currentLine < endLine - 1)
                {
                    currentLine++;
                    text.text = textLines[currentLine];
                }
                else
                {

                    dialogPanel.SetActive(false);
                    imported = false;
                    if (Mathf.Abs(player.transform.position.x - FBI.transform.position.x) < 0.3 && Mathf.Abs(player.transform.position.y - FBI.transform.position.y) < 0.3f)
                    {
                        if (!GameManager.fightedFBI)
                        {
                            SceneManager.LoadScene("FightInDowntown");
                            
                        }
                        else
                        {
                            GameManager.mazeMapGet = true;
                            cabby.SetActive(true);
                        }
                    }
                    if (Mathf.Abs(player.transform.position.x - cabby.transform.position.x) < 0.3 && Mathf.Abs(player.transform.position.y - cabby.transform.position.y) < 0.3f)
                    {
                        SceneManager.LoadScene("Maze");
                    }
                }
            }
        }
        

        if (GameManager.showFBI)
        {
            FBI.SetActive(true);
        }

        if (GameManager.fightedFBI)
            cabby.SetActive(true);
    }

    public void HideGet()
    {
        get.SetActive(false);
    }
}

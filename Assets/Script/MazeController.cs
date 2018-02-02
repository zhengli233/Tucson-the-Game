using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MazeController : MonoBehaviour {

    public static int step = 0;
    public static int[] playerRoute = new int[10];
    public static int[] route = new int[10];
    public static int whichAlien = 0;
    public static Vector2 currentPos;
    public static bool fightedCreeps = false;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;

    public GameObject player;
    public GameObject alien;

    public GameObject professor;
    public GameObject alien1;
    public GameObject alien2;
    public GameObject alien3;
    public GameObject alien4;

    public Text text;
    public TextAsset alienText;
    public GameObject dialogPanel;
    public GameObject mapPanel;
    public Text mapText;

    //    public static List<Maze> route;
    

    public bool wrongWay;
    public int showStep;
    public bool map;
    public int[] showRoute = new int[10];
    public int[] showPlayerRoute = new int[10];

    public string[] textLines;
    int currentLine;
    int endLine;
    bool imported;

    /*    public Maze d2 = new Maze
        {
            up = 0,
            down = 0
        };
        public Maze d3 = new Maze
        {
            down = 0
        };
        public Maze d4 = new Maze();
        public Maze d1 = new Maze();

        public class Maze
        {

            public int up;
            public int down;
            public int left;
            public int right;
        }
    */
    // Use this for initialization
    void Start () {
        
        InitiateMaze();
        door4.SetActive(true);
        alien.SetActive(false);
        door1.SetActive(false);

        professor.SetActive(false);
    }

    private void OnEnable()
    {
        if (GameManager.currentMap != 0)
            GameManager.previousMap = GameManager.currentMap;
        GameManager.currentMap = 8;
        if (GameManager.previousMap == 10)
            player.transform.position = currentPos;
        if (fightedCreeps && whichAlien != 0)
        {
            if (whichAlien == 1)
                alien1.SetActive(false);
            if (whichAlien == 2)
                alien2.SetActive(false);
            if (whichAlien == 3)
                alien3.SetActive(false);
            if (whichAlien == 4)
                alien4.SetActive(false);            
        }
        
    }

    // Update is called once per frame
    void Update () {
        showStep = step;
        currentPos = player.transform.position;
        if (whichAlien == 0 && step < 4)
        {
            alien1.SetActive(true);
            alien2.SetActive(true);
            alien3.SetActive(true);
            alien4.SetActive(true);
        }
        //        GameManager.mazeMapGet = map;
        if (route[step] != playerRoute[step])
        {
            wrongWay = true;
            step = 0;
        }            
        else
            wrongWay = false;
        if (step > 3)
        {
            door4.SetActive(false);
            door1.SetActive(true);
            if (!wrongWay)
            {
                alien.SetActive(true);
                professor.SetActive(true);
                if (Mathf.Abs(player.transform.position.x - alien.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y - alien.transform.position.y) < 0.5f)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (alienText != null)
                        {
                            textLines = alienText.text.Split('\n');
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
                            SceneManager.LoadScene("FightInMaze");
                        }
                    }
                }
            }
        }
        showPlayerRoute[step] = playerRoute[step];

        if (dialogPanel.activeSelf)
            GameManager.lockPlayer = true;
        else
            GameManager.lockPlayer = false;

        if (alien1.activeSelf)
        {
            if (Mathf.Abs(player.transform.position.x - alien1.transform.position.x) < 0.2 && Mathf.Abs(player.transform.position.y - alien1.transform.position.y) < 0.2)
            {
                whichAlien = 1;
                SceneManager.LoadScene("FightCreeps");
            }
        }
        if (alien2.activeSelf)
        {
            if (Mathf.Abs(player.transform.position.x - alien2.transform.position.x) < 0.2 && Mathf.Abs(player.transform.position.y - alien2.transform.position.y) < 0.2)
            {
                whichAlien = 2;
                SceneManager.LoadScene("FightCreeps");
            }
        }
        if (alien3.activeSelf)
        {
            if (Mathf.Abs(player.transform.position.x - alien3.transform.position.x) < 0.2 && Mathf.Abs(player.transform.position.y - alien3.transform.position.y) < 0.2)
            {
                whichAlien = 3;
                SceneManager.LoadScene("FightCreeps");
            }
        }
        if (alien4.activeSelf)
        {
            if (Mathf.Abs(player.transform.position.x - alien4.transform.position.x) < 0.2 && Mathf.Abs(player.transform.position.y - alien4.transform.position.y) < 0.2)
            {
                whichAlien = 4;
                SceneManager.LoadScene("FightCreeps");
            }
        }
      
    }

    public void InitiateMaze()
    {
        if (!GameManager.initMaze)
        {
            System.Random rnd = new System.Random();

            for (int i = 1; i < 5; i++)
            {
                route[i] = rnd.Next(1, 4);
                GameManager.route[i] = route[i];
                showRoute[i] = route[i];
            }
            GameManager.initMaze = true;
        }
        else
        {
            for (int j = 1; j < 5; j++)
            {
                route[j] = GameManager.route[j];
                showRoute[j] = route[j];
            }
        }
    }

    public void UseMap()
    {
        mapText.text = "";
        for (int i = 1; i < 5; i++)
        {
            if (route[i] == 1)
            {
                mapText.text += "L ";
            }
            if (route[i] == 2)
            {
                mapText.text += "U ";
            }
            if (route[i] == 3)
            {
                mapText.text += "R ";
            }
            if (route[i] == 4)
            {
                mapText.text += "D ";
            }
        }
        mapPanel.SetActive(true);
    }
}

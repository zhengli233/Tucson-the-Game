using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FinalController : MonoBehaviour {

    public static int dialogInFinal;

    public GameObject player;
    public GameObject FBI;
    public GameObject professor;

    public GameObject dialogPanel;
    public Text dialogText;
    public TextAsset professorText;

    public GameObject get;
    public Text getText;

    public string[] textLines;
    int currentLine;
    int endLine;
    bool imported;

    // Use this for initialization
    /*    void Start () {
            getText.text = "Get Ray Gun!";
            get.SetActive(true);
            GameManager.rayGunGet = true;
            Invoke("HideGet", 2f);
        }*/

    private void Start()
    {
        if (professorText != null)
        {
            textLines = professorText.text.Split('\n');
            endLine = textLines.Length;
            currentLine = 0;
            imported = true;
            dialogText.text = textLines[currentLine];
            dialogPanel.SetActive(true);
        }
    }

    private void OnEnable()
    {
        if (GameManager.currentMap != 0)
            GameManager.previousMap = GameManager.currentMap;
        GameManager.currentMap = 9;

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

        if (dialogPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("space"))
            {

                if (currentLine < endLine - 1)
                {
                    currentLine++;
                    dialogText.text = textLines[currentLine];
                }
                else
                {

                    dialogPanel.SetActive(false);
                    imported = false;
                    SceneManager.LoadScene("Ending");
                }
            }
        }
    }

    public void HideGet()
    {
        get.SetActive(false);
        dialogInFinal = 1;
        
    }
}

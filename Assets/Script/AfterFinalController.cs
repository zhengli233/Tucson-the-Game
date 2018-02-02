using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AfterFinalController : MonoBehaviour {

    public GameObject player;

    public GameObject FBI;
    public GameObject professor;

    public Text text;
    public TextAsset professorText;
    public GameObject dialogPanel;

    public string[] textLines;
    int currentLine;
    int endLine;
    bool imported;


    // Use this for initialization
    void Start () {
        if (professorText != null)
        {
            textLines = professorText.text.Split('\n');
            endLine = textLines.Length;
            currentLine = 0;
            imported = true;
            text.text = textLines[currentLine];
            dialogPanel.SetActive(true);
        }
        dialogPanel.SetActive(true);
    }

    private void OnEnable()
    {
        if (GameManager.currentMap != 0)
            GameManager.previousMap = GameManager.currentMap;
        GameManager.currentMap = 12;
    }

    // Update is called once per frame
    void Update () {
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
                    SceneManager.LoadScene("Ending");
                }
            }
        }
    }
}

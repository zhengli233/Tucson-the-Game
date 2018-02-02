using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JailController : MonoBehaviour {

    public GameObject dialogPanel;
    public Text text;
    public TextAsset textAsset;

    public string[] textLines;
    int currentLine;
    int endLine;
    bool imported;

    // Use this for initialization
    void Start()
    {
        if (textAsset != null)
        {
            textLines = textAsset.text.Split('\n');
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
        GameManager.currentMap = 14;
    }

    // Update is called once per frame
    void Update()
    {
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
                    SceneManager.LoadScene("OuterSpace");
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class InteractionInSS : MonoBehaviour {

    public static int dialogInSS;
    

    public GameObject player;
    public GameObject crazyCustomer;
    public GameObject sarah;
    public GameObject footballPad;
    public GameObject baseballBat;
    public GameObject helmat;
    public GameObject get;
    public Text text;


	// Use this for initialization
	void Start () {
        if(!GameManager.winFightInSS)
            dialogInSS = 1;
	}

    private void OnEnable()
    {
        if (GameManager.currentMap != 0)
            GameManager.previousMap = GameManager.currentMap;
        GameManager.currentMap = 4;

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

        if (GameManager.winFightInSS)
        {
            text.text = "Aquired skill: Defend!";
            get.SetActive(true);
            Invoke("HideGetImage", 2f);
        }
    }

    // Update is called once per frame
    void Update () {


        if (Mathf.Abs(player.transform.position.x - footballPad.transform.position.x) < 0.2 && Mathf.Abs(player.transform.position.y - footballPad.transform.position.y) < 0.2)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                footballPad.SetActive(false);
                GameManager.footballPadGet = true;
                text.text = "Get FOOTBALL PAD!";
                get.SetActive(true);
                Invoke("HideGetImage", 2f);
            }
        }

        if (Mathf.Abs(player.transform.position.x - baseballBat.transform.position.x) < 0.2 && Mathf.Abs(player.transform.position.y - baseballBat.transform.position.y) < 0.2)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                baseballBat.SetActive(false);
                GameManager.baseballBatGet = true;
                text.text = "Get BASEBALL BAT!";
                get.SetActive(true);
                Invoke("HideGetImage", 2f);
            }
        }

        if (Mathf.Abs(player.transform.position.x - helmat.transform.position.x) < 0.2 && Mathf.Abs(player.transform.position.y - helmat.transform.position.y) < 0.2)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                helmat.SetActive(false);
                GameManager.helmatGet = true;
                text.text = "Get HELMAT!";
                get.SetActive(true);
                Invoke("HideGetImage", 2f);
            }
        }

        if (Mathf.Abs(player.transform.position.x - crazyCustomer.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y - crazyCustomer.transform.position.y) < 0.5)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogInSS = 2;
            }
        }

        if (Mathf.Abs(player.transform.position.x - sarah.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y - sarah.transform.position.y) < 0.5)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameManager.winFightInSS)
                {
                    dialogInSS = 3;
                }
            }
        }
        if (Mathf.Abs(player.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y + 3.7f) < 0.2f)
        {
            SceneManager.LoadScene("Downtown");
        }

        if (GameManager.winFightInSS)
        {
            crazyCustomer.SetActive(false);
        }
    }

    void HideGetImage()
    {
        get.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class InteractionInBar : MonoBehaviour {

    public static int dialogInBar = 0;
    

    public GameObject player;
    public GameObject noramlCustomer;
    public GameObject complainCustomer;
    public GameObject cheatingCustomer;
    public GameObject boss;

    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable()
    {
        if (GameManager.currentMap != 0)
            GameManager.previousMap = GameManager.currentMap;
        GameManager.currentMap = 3;

        if (GameManager.previousMap == 5)
        {
            Vector2 pos;
            pos.x = 1.904f;
            pos.y = -1.709f;
            player.transform.position = pos;
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

        if (GameManager.cheatDiceGet)
            cheatingCustomer.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (Mathf.Abs(player.transform.position.x - noramlCustomer.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y - noramlCustomer.transform.position.y) < 0.2)
        {
            
            if (Input.GetKey("e"))
            {
                dialogInBar = 1;
            }
        }
        if (!GameManager.cheatDiceGet)
        {
            if (Mathf.Abs(player.transform.position.x - complainCustomer.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y - complainCustomer.transform.position.y) < 0.2)
            {

                if (Input.GetKey("e"))
                {
                    dialogInBar = 2;
                }
            }
            if (Mathf.Abs(player.transform.position.x - cheatingCustomer.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y - cheatingCustomer.transform.position.y) < 0.2)
            {

                if (Input.GetKey("e"))
                {
                    dialogInBar = 3;
                }
            }
        }
        
        if (Mathf.Abs(player.transform.position.x - boss.transform.position.x) < 0.5 && Mathf.Abs(player.transform.position.y - boss.transform.position.y) < 0.2)
        {

            if (Input.GetKeyDown("e"))
            {
                if (!GameManager.askedBoss)
                    dialogInBar = 4;
                else
                {
                    if (GameManager.winFightInBar)
                        dialogInBar = 6;
                    else
                        dialogInBar = 5;
                }             
            }
        }
        if (Mathf.Abs(player.transform.position.x) < 1 && player.transform.position.y < -2.99f)
        {
            
            SceneManager.LoadScene("Downtown");
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleItem : MonoBehaviour {

    public Button button;
    public Text itemName;

    private Item item;

    // Use this for initialization
    void Start() {

    }

    public void SetUp(Item inputItem)
    {
        item = inputItem;
        itemName.text = item.itemName;
        if (itemName.text.Equals("Calculator", System.StringComparison.Ordinal))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(UseCalculator);
            Debug.Log("initial calculator function");
        }
        else if (itemName.text.Equals("Pencil", System.StringComparison.Ordinal))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(UsePencil);
            Debug.Log("initial pencil function");
        }
        else if (itemName.text.Equals("Eegee's", System.StringComparison.Ordinal))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(UseEegee);
        }
        else if (itemName.text.Equals("Dice(cheat)", System.StringComparison.Ordinal))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(UseCheatDice);
        }
        else if (itemName.text.Equals("Dice", System.StringComparison.Ordinal))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(UseNormalDice);
        }
        else if (itemName.text.Equals("Special Beer", System.StringComparison.Ordinal))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(UseBeer);
        }
        else if (itemName.text.Equals("Football Pad", System.StringComparison.Ordinal))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(UseFootballPad);
        }
        else if (itemName.text.Equals("Baseball Bat", System.StringComparison.Ordinal))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(UseBaseballBat);
        }
        else if (itemName.text.Equals("Helmat", System.StringComparison.Ordinal))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(UseHelmat);
        }
        else if (itemName.text.Equals("Map", System.StringComparison.Ordinal))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(UseMap);
        }
        else if (itemName.text.Equals("Ray Gun", System.StringComparison.Ordinal))
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(UseRayGun);
        }
    }

    public void UseCalculator()
    {
        GameObject.Find("BattleContorller").GetComponent<BattleController>().UseCal();
        Debug.Log("use calllllll");
        GameObject.Find("Items").SetActive(false);
    }

    public void UsePencil()
    {
        GameObject.Find("BattleContorller").GetComponent<BattleController>().UsePen();
        Debug.Log("use pencil");
        GameObject.Find("Items").SetActive(false);
    }

    public void UseEegee()
    {
        GameObject.Find("FightInMazeController").GetComponent<FightInMaze>().UseEegee();
        GameObject.Find("Items").SetActive(false);
    }

    public void UseCheatDice()
    {
        GameObject.Find("FightInBarController").GetComponent<FightInBarController>().UseCheatDice();
        GameObject.Find("Items").SetActive(false);
    }

    public void UseNormalDice()
    {
        GameObject.Find("FightInBarController").GetComponent<FightInBarController>().UseNormalDice();
        GameObject.Find("Items").SetActive(false);
    }

    public void UseBeer()
    {
        if (GameObject.Find("Controller").GetComponent<FightInSS>())
        {
            GameObject.Find("Controller").GetComponent<FightInSS>().UseBeer();
        }
        if (GameObject.Find("Controller").GetComponent<FightInDowntown>())
        {
            GameObject.Find("Controller").GetComponent<FightInDowntown>().UseBeer();
        }
        GameObject.Find("Items").SetActive(false);
    }

    public void UseFootballPad()
    {
        if (GameObject.Find("Controller").GetComponent<FightInSS>())
        {
            GameObject.Find("Controller").GetComponent<FightInSS>().UseFootballPad();
        }
        if (GameObject.Find("Controller").GetComponent<FightInDowntown>())
        {
            GameObject.Find("Controller").GetComponent<FightInDowntown>().UseFootballPad();
        }
        GameObject.Find("Items").SetActive(false);
    }

    public void UseBaseballBat()
    {
        if (GameObject.Find("Controller").GetComponent<FightInSS>())
            GameObject.Find("Controller").GetComponent<FightInSS>().UseBaseballBat();
        if (GameObject.Find("Controller").GetComponent<FightInDowntown>())
            GameObject.Find("Controller").GetComponent<FightInDowntown>().UseBaseballBat();
        GameObject.Find("Items").SetActive(false);
    }

    public void UseHelmat()
    {
        if (GameObject.Find("Controller").GetComponent<FightInSS>())
            GameObject.Find("Controller").GetComponent<FightInSS>().UseHelmat();
        if (GameObject.Find("Controller").GetComponent<FightInDowntown>())
            GameObject.Find("Controller").GetComponent<FightInDowntown>().UseHelmat();
        GameObject.Find("Items").SetActive(false);
    }

    public void UseMap()
    {
        if (GameObject.Find("MazeController").GetComponent<MazeController>())
        {
            GameObject.Find("MazeController").GetComponent<MazeController>().UseMap();
        }
        GameObject.Find("Items").SetActive(false);
    }

    public void UseRayGun()
    {
        if (GameObject.Find("Controller").GetComponent<FightInFinal>())
        {
            GameObject.Find("Controller").GetComponent<FightInFinal>().UseRayGun();
        }
    }
}

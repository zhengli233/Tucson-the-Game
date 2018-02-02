using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemNum;
}

public class ItemList : MonoBehaviour {
    public List<Item> list;

    public Transform content;
    public ItemPool buttonObjectPool;

	// Use this for initialization
	void OnEnable () {
        list.Clear();
        if (GameManager.calculatorGet)
        {
            Item calculatorItem = new Item
            {
                itemName = "Calculator",
                itemNum = 0
            };
            list.Add(calculatorItem);
        }

        if (GameManager.pencilGet)
        {
            Item pencilItem = new Item
            {
                itemName = "Pencil",
                itemNum = 1
            };
            list.Add(pencilItem);
        }

        if (GameManager.eegeeGet)
        {
            Item eegeeItem = new Item
            {
                itemName = "Eegee's",
                itemNum = 2
            };
            list.Add(eegeeItem);
        }

        if (GameManager.cheatDiceGet)
        {
            Item cheatDiceItem = new Item
            {
                itemName = "Dice(cheat)",
                itemNum = 3
            };
            list.Add(cheatDiceItem);
        }

        if (GameManager.normalDiceGet)
        {
            Item normalDiceItem = new Item
            {
                itemName = "Dice",
                itemNum = 4
            };
            list.Add(normalDiceItem);
        }

        if (GameManager.beerGet)
        {
            Item beerItem = new Item
            {
                itemName = "Special Beer",
                itemNum = 5
            };
            list.Add(beerItem);
        }

        if (GameManager.footballPadGet)
        {
            Item footballPadItem = new Item
            {
                itemName = "Football Pad",
                itemNum = 6
            };
            list.Add(footballPadItem);
        }

        if (GameManager.baseballBatGet)
        {
            Item baseballBatItem = new Item
            {
                itemName = "Baseball Bat",
                itemNum = 7
            };
            list.Add(baseballBatItem);
        }

        if (GameManager.helmatGet)
        {
            Item helmatItem = new Item
            {
                itemName = "Helmat",
                itemNum = 8
            };
            list.Add(helmatItem);
        }

        if (GameManager.mazeMapGet)
        {
            Item mapItem = new Item
            {
                itemName = "Map",
                itemNum = 9
            };
            list.Add(mapItem);
        }

        if (GameManager.rayGunGet)
        {
            Item rayGunItem = new Item
            {
                itemName = "Ray Gun",
                itemNum = 10
            };
            list.Add(rayGunItem);
        }
        RemoveButtons();
        AddButtons();

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void AddButtons()
    {
        for (int i = 0; i < list.Count; i++)
        {
            Item item = list[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(content);

            

            SampleItem sampleItem = newButton.GetComponent<SampleItem>();
            sampleItem.SetUp(item);
            
        }
    }

    private void RemoveButtons()
    {
        while (content.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }
}

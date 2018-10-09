using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour {

    public Image image;

    public int dictIndex;

    public void Use()
    {
        
    }
}

public class ItemManager : MonoBehaviour {

    public List<Item> publicInventory;
    public static Dictionary<int, Item> itemDictionary;

    public Dictionary<int, int> currInventory;

	// Use this for initialization
	void Start () {
        SetDictionary();
	}
	
    public void SetDictionary()
    {
        foreach(Item i in publicInventory)
        {
            itemDictionary.Add(i.dictIndex, i);
        }
        print(itemDictionary);
    }

	// Update is called once per frame
	void Update () {
		
	}
}

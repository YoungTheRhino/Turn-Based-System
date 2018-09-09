using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HealItem{
    int Heal();
}

public class Potion : Item, HealItem {

    //public int dictIndex = 1;
	// Use this for initialization
	void Start () {
		
	}

    int  HealItem.Heal(){
        return 2;
    }
	// Update is called once per frame
	void Update () {
		
	}
}

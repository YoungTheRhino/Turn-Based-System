using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOption : MonoBehaviour {


    public int selectValue;

    Text menuLabel;

    public Color hColor;

    public MenuScript subMenu;



	// Use this for initialization
	void Start () {
        menuLabel = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool SubMenuCheck()
    {
        return (subMenu != null) ? true : false;
    }

    public void HighlightText(bool b)
    {
        if (b)
        {
            menuLabel.color = hColor;
        }
        else
        {
            menuLabel.color = Color.black;
        }
    }

    public int SelectOption()
    {
        return selectValue;
    }
}

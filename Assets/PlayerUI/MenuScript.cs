using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public List<MenuScript> subMenus;
    int menuIndex = 0;

    public int selectValue = 0;

    Text menuLabel; //highlight when hover
    public Color hColor;

	// Use this for initialization
	void Start () {
        
        foreach(Transform child in transform)
        {
            subMenus.Add(child.GetComponent<MenuScript>());
        }
        menuLabel = GetComponent<Text>();
	}


    public void HighlightText(bool b)
    {
        if(b)
        {
            menuLabel.color = hColor;
        }
        else{
            menuLabel.color = Color.black;
        }
    }

    public void Activate()
    {
        
    }

    public void Deactivate()
    {
        //turn display off
    }

    public void NavMenu(int dir){
        if(subMenus.Count == 0)
        {
            return;
        }
        subMenus[menuIndex].HighlightText(false);
        menuIndex += dir;
        menuIndex = Mathf.Clamp(menuIndex, 0, subMenus.Count - 1);
        if (menuIndex < 0) menuIndex = 0;
        subMenus[menuIndex].HighlightText(true);
    }

    public MenuScript Select()
    {
        if(subMenus == null || subMenus.Count == 0)
        {
            return null;
        }
        else
        {
            return subMenus[menuIndex];    
        }
    }
	
    public int OptionLength(){
        return subMenus.Count;
    }

    public MenuScript getIndexRef()
    {
        return subMenus[menuIndex];
    }

	// Update is called once per frame
	void Update () {
		
	}
}

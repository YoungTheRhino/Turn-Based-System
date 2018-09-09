using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//menuitem

public class MenuScript : MonoBehaviour {

    public bool dynamicFill;
    public List<MenuOption> subMenus;//menuitems

    int menuIndex = 0;
    Image image;
    //highlight when hover
 

	// Use this for initialization
	void Start () {

        image = GetComponent<Image>();
        if(dynamicFill)
        {

            foreach (MenuOption m in GetComponentsInChildren<MenuOption>())
            {
                subMenus.Add(m);
            }
        }
	}



    public void Activate()
    {
        image.enabled = true;
    }

    public void Deactivate()
    {
        image.enabled = false;//turn display off
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

    public MenuOption ToNextMenu()
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

    public MenuOption getIndexRef()
    {
        return subMenus[menuIndex];
    }

	// Update is called once per frame
	void Update () {
		
	}
}

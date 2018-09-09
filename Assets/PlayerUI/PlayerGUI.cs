using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : ActorGUI
{
    public MenuScript topMenu;

    pcScript playerScript;



    public Stack<MenuScript> menuStack = new Stack<MenuScript>();//list of text options

    Coroutine inputCoroutine;

    public void SetPlayer(pcScript p)
    {
        playerScript = p;
        
    }

    public void Turn()
    {
        menuStack.Push(topMenu);
        menuStack.Peek().NavMenu(0); //turn on Combat Menu, input subroutine
        Debug.Log("PlayerGUI turn");
        
        inputCoroutine = StartCoroutine(InputMenu());

    }

    IEnumerator InputMenu()
    {
        while(true)
        {
            if (Input.GetKeyDown("w"))
            {
                Debug.Log("Input Menu()");
                menuStack.Peek().NavMenu(-1);
            }
            else if (Input.GetKeyDown("s"))
            {
                Debug.Log("Input Menu()");
                menuStack.Peek().NavMenu(1);
            }
            else if (Input.GetKeyDown("space"))
            {
                playerScript.MenuAction(Select());

            }
            else if (Input.GetKeyDown("backspace"))
            {
                BackMenu();
            }
            yield return null;
        }
        
    }

    public int Select()
    {
        
        if(menuStack.Count == 0)
        {
            return 0;
        }
        MenuScript temp = menuStack.Peek();
        if(temp.OptionLength() == 0)
        {
            return -1;
        }
        int i = temp.getIndexRef().SelectOption();
        switch(i)
        {
            case 0: // subMenu is activated, turn not done yet
                temp.Deactivate();
                menuStack.Push(temp.ToNextMenu().subMenu);
                menuStack.Peek().Activate();
                break;

            case -1:
                BackMenu();
                i = 0;
                break;

            default: //end is reached, no more submenus to traverse
                StopCoroutine(inputCoroutine);
                while (menuStack.Count > 0)
                {
                    menuStack.Pop().Deactivate();
                }
                break;

        }

        return i;
    }


    void BackMenu()
    {
        if(menuStack.Count <= 1)
        {
            return;
        }
        menuStack.Pop().Deactivate();
        menuStack.Peek().Activate();
    }
}
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
        if (temp.getIndexRef().OptionLength() == 0)
        {
            print(menuStack.Count);
            StopCoroutine(inputCoroutine);
            while(menuStack.Count > 0)
            {
                menuStack.Pop().Deactivate();
            }
            return temp.selectValue;
        }
        else
        {
            temp.Deactivate();
            menuStack.Push(temp.Select());
            menuStack.Peek().Activate();
            return 0;
        }

    }
}
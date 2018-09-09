using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcScript : EntityScript {

    public PlayerGUI playerGUI;
    public PlayerStats stats;

	// Use this for initialization
	void Start () {
        stats = GetComponent<PlayerStats>();
	}

    public override void InitializeCombat(List<EntityScript> t)
    {
        playerGUI.SetPlayer(this);
        base.InitializeCombat(t);

    }
	
    public override void Turn()
    {
        base.Turn();
        playerGUI.Turn();
        //start input subroutine
    }

    public void MenuAction(int i)
    {
        switch(i)
        {
            case 1:
                battleManager.Attack(this, targetEntities[0], attackList[0]);
                
                break;

            case 2:
                //sub menu select item, return
                break;

            default:
                return; //continue the menu

        }
        //reset menus
    }
	// Update is called once per frame
	public override void Update () {
		
	}

    public void EnemyDefeated(EnemyScript e)
    {
        stats.EXPGain(e.EXPreturn());
    }
}

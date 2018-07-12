using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(EntityVariables))]
[ExecuteInEditMode]

public class EntityScript : MonoBehaviour {

	public BattleManager battleManager;

	[System.Serializable]
	public class Attack{
		public string name;
		public int damage;
		public List<StatusLibrary.StatusEnum> effectList;


	}
	[SerializeField]
	public List<Attack> attackList;

    public ActorGUI combatGUI;

    public List<EntityScript> targetEntities;

	EntityVariables script;

	public GameObject attackObject;

	public EntityScript target;


	[SerializeField]
	List<StatusLibrary.StatusEnum> onEffects = new List<StatusLibrary.StatusEnum> ();

    bool active = true;


	public bool attacking;


	void Awake()
	{
        script = GetComponent<EntityVariables>();
		
	}

    public bool ActiveCheck()
    {
        return active;
    }
	protected virtual void Start()
	{
		

	}

    public virtual void InitializeCombat(List<EntityScript> t)
    {
        if(combatGUI)
        {
            combatGUI.UpdateHealth(script.getHealth());
            Debug.Log(script.getHealth());
        }

        targetEntities = t;
    }

    public void InitializeCombat(List<pcScript> t)
    {
        if (combatGUI)
        {
            combatGUI.UpdateHealth(script.getHealth());
            Debug.Log(script.getHealth());
        }

        foreach( pcScript p in t)
        {
            targetEntities.Add(p);
        }
    }

    public virtual void Turn()
	{
		attacking = true;
	}

	public void EndTurn()
	{
        StatusLibrary.EndTurn(onEffects, this);
		attacking = false;
	}

	public virtual void Update()
	{
		if (attacking && Input.GetKeyDown ("t")) {

            battleManager.Attack(this, targetEntities[0], attackList[0]);

			EndTurn ();
		}
	}

	public void Deletion()
	{

	}

    public int TakeDamage(int damage)
    {
        int temp = script.TakeDamage(damage);
        if(combatGUI)
        {
            combatGUI.UpdateHealth(temp);
        }
        return temp;
    }

    public virtual void HPZero()
    {
        active = false;

    }

    public bool Afflicted(StatusLibrary.StatusEnum e)
    {
        if(!onEffects.Contains(e))
        {
            onEffects.Add(e);
            return true;
        }
        else{
            return false;
        }

    }
}

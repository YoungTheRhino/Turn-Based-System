using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
	public EntityScript entityAttacking;
	public List<EntityScript> entityList;
	public List<EntityScript> enemylist = new List<EntityScript>();
	public List<EntityScript> enemiesdefeated = new List<EntityScript>();

	public BattleManager battleManager;

    bool active = true;

    Coroutine turnCoroutine;
	void Start()
	{
       
    }
	public void StartCombat(List<pcScript> playerList, List<EntityScript> enemyList)
	{
		foreach (pcScript entity in playerList) {
			entityList.Add(entity);
		}		
		foreach (EntityScript entity in enemyList) {
			entityList.Add(entity);
		}
		//get better entity discovery, get fed information by BattleManager
		EnemyCount();

	}

	void EnemyCount()
	{
		enemylist.Clear();
		//currentenemies = GameObject.FindObjectsOfType<EntityScript>(); //get better entity discovery, get fed information by BattleManager

		if (entityList.Count > 0)
		{
			foreach (EntityScript character in entityList)
			{
				enemylist.Add(character);
				enemylist.Sort(delegate (EntityScript a, EntityScript b)
					{
						return (b.GetComponent<EntityVariables>().getSpeed().CompareTo(a.GetComponent<EntityVariables>().getSpeed()));

					});

			}
            turnCoroutine = StartCoroutine(EnemyTurn());

		}
		else if(entityList.Count == 0)
		{
			//EndCombat();
		}
	}



	IEnumerator EnemyTurn()
	{
        if(!active)
        {
            EndCombat();
            yield return null;
        }
		foreach (EntityScript enemy in enemylist)
		{
			if (enemy != null && enemy.ActiveCheck())
			{
				enemy.Turn();
				entityAttacking = enemy;
				if (entityAttacking != null) {
					yield return new WaitWhile (() => entityAttacking.attacking);
				}


				
			}
		}
        
		EnemyCount();
        
	}

	public void DeleteEnemies()
	{
		

	}
	public void EndCombat()
	{
		if (entityAttacking != null)
		{
			entityAttacking.EndTurn();
            
        }
        StopCoroutine(turnCoroutine);
        //DeleteEnemies();
        for (int i = 0; i < enemylist.Count; i++)
		{
			Debug.Log(enemylist[i] + " should be deleted");
			//enemylist[i].GetComponent<EnemyScript>().Deletion();
			enemylist[i] = null;
			Debug.Log("Destroy");
		}
		entityList.Clear ();
		entityAttacking = null;
		Debug.Log("EndCombat");
		enemylist.Clear();
        battleManager.CombatEnd();


	}

	public void PlayerDeath()
	{
		//enemyAttacking.StopAttacking();
		//StopCoroutine(EnemyTurn());
	}

    public void EndCheck()
    {
        active = false;
    }
}

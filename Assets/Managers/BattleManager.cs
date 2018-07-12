using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AttackEnum
{
	none,
	poison,
	debuff,
	loseTurn

}

public class BattleManager : MonoBehaviour {

	public TurnManager turnManager;

	public List<GameObject> playerList = new List<GameObject> ();
	public List<GameObject> enemyList = new List<GameObject>();

	private List<GameObject> playersDefeated = new List<GameObject> ();
    List<pcScript> currentPlayers = new List<pcScript>();

	public List<EntityScript> enemiesDefeated = new List<EntityScript>();

    [Header("UI Objects")]
    public PlayerGUI playerUI;

	public List<EntityScript> activeEnemies = new List<EntityScript>();

	//List<StatusEffects> currentStatus
	//List<EndofTurn> endTurnEffects;
	//List<AttackingEffects> attackEffects;

	void Start()
	{
        turnManager.battleManager = this;
		StartCombat ();
	}
	public void StartCombat()
	{
		SpawnEntities ();
	}

	void SpawnEntities()
	{
		
		List<EntityScript> currentEnemies = new List<EntityScript> ();
		foreach (GameObject entity in playerList)
		{
			pcScript e = Instantiate (entity).GetComponent<pcScript> ();
			currentPlayers.Add (e);
            Debug.Log(e);
			// TODO Place them on the screen
		}

		foreach (GameObject entity in enemyList)
		{
			EntityScript e = Instantiate (entity).GetComponent<EntityScript> ();
			e.battleManager = this;
            e.InitializeCombat(currentPlayers);
			currentEnemies.Add (e);

			// TODO Place them on the screen
		}

        foreach (pcScript entity in currentPlayers)
        {

            entity.battleManager = this;
            entity.playerGUI = playerUI;
            entity.combatGUI = playerUI;
            entity.InitializeCombat(currentEnemies);
            // TODO Place them on the screen
        }
		activeEnemies = currentEnemies;
		turnManager.StartCombat (currentPlayers, currentEnemies);
	}

	public void Attack(EntityScript user, EntityScript target, EntityScript.Attack attack)
	{
        
        foreach(StatusLibrary.StatusEnum e in attack.effectList)
        {
            
            target.Afflicted(e);
        }
        if (target.TakeDamage(attack.damage) <= 0)
        {
            target.HPZero();
            activeEnemies.Remove(target);
            FinishCheck();
        }
        
    }

    void FinishCheck()
    {
        if(activeEnemies.Count == 0)
        {
            turnManager.EndCheck();
        }
    }

    public void CombatEnd()
    {

    }

    public void EnemyDeath(EnemyScript e)
    {
        
        foreach(pcScript p in currentPlayers)
        {
            
            p.EnemyDefeated(e);
        }
    }
}

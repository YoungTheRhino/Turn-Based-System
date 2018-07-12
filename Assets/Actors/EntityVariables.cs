using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityScript))]
public class EntityVariables : MonoBehaviour {

	public List<StatusEffect> statusEffects = new List<StatusEffect> ();

    [System.Serializable]
    public struct CombatStats
    {
		public int maxHealth;
        public int speed;
        public int attack;
    }
    [SerializeField]
    public CombatStats combatStats;

    [SerializeField]
    int currentHealth;

	void Start()
	{
       
	}
	public int TakeDamage(int d)
	{
		currentHealth -= d;
		currentHealth = Mathf.Clamp (currentHealth, 0, combatStats.maxHealth);
        return currentHealth;
	}

    public void Defeat()
    {

    }
	public int getSpeed()
	{
		return combatStats.speed;
	}

    public int getHealth()
    {
        return currentHealth;
    }

    public void LevelUpStats(CombatStats c)
    {
        combatStats.maxHealth += c.maxHealth;
        combatStats.attack += c.attack;
        combatStats.speed += c.speed;
    }
}

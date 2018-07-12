using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    const int MAXIMUM_EXP = 1000000;

    EntityVariables variables;
    public int levelCap;

    [System.Serializable]
    public struct LevelStruct 
    {
        public EntityVariables.CombatStats stats;
        public int requiredEXP;
    }

    [SerializeField]
    public List<LevelStruct> levelStats;
    public int currentLvl;
    public int currentExperiencePoints;
    
	// Use this for initialization
	void Start () {
        currentExperiencePoints = Mathf.Clamp(currentExperiencePoints, 0, MAXIMUM_EXP);
        variables = GetComponent<EntityVariables>();
	}
	
    public void EXPGain(int xp)
    {
        if (currentLvl >= levelStats.Count) return;
        currentExperiencePoints += xp;
        LevelCheck();
    }
    void LevelCheck()
    {
        if (currentLvl >= levelStats.Count) return;
        if(currentExperiencePoints >= levelStats[currentLvl].requiredEXP)
        {
            
            currentExperiencePoints -= levelStats[currentLvl].requiredEXP;
            currentLvl += 1;
            variables.LevelUpStats(levelStats[currentLvl].stats);
            LevelCheck();
        }


    }
	// Update is called once per frame
	void Update () {
		
	}
}

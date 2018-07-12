using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : EntityScript {

    EnemyEXP expComponent;

    protected override void Start()
    {
        expComponent = GetComponent<EnemyEXP>();
    }

	public override void HPZero()
    {
        base.HPZero();
        battleManager.EnemyDeath(this);


    }

    public int EXPreturn()
    {
        return expComponent.rewardEXP;
    }
}

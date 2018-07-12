using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonEffect : StatusEffect, EndofTurn
{
	public int damage = 2 ;
	public override void Affect(EntityScript t)
	{
		t.TakeDamage (damage);
	}
}

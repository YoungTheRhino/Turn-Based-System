using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EndofTurn
{
	void Affect (EntityScript target);
}


public interface Attacking
{
	void Affect (EntityScript target);
}


public class StatusManager
{
	
}
public class StatusEffect// : MonoBehaviour
{

	public virtual void Affect(EntityScript target)
	{

	}
}



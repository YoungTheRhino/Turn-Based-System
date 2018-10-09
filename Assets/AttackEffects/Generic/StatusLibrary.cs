using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct StatusStruct
{
    public PoisonEffect poison;
}

public static class StatusLibrary  {

    static PoisonEffect poison = new PoisonEffect();
    static StatusStruct statusStruct;
    public enum StatusEnum { 

        poison, 
        none 
    
    
    };

    public static void EndTurn(List<StatusLibrary.StatusEnum> enums, EntityScript target)
    {
        foreach (StatusLibrary.StatusEnum e in enums)
        {
            if (EnumToEffect(e) is EndofTurn)
            {
                EnumToEffect(e).Affect(target);
                Debug.Log(e + " " + target);
            }

        }
    }

    static StatusEffect EnumToEffect(StatusLibrary.StatusEnum e)
    {
        switch(e)
        {
            case StatusEnum.poison:
                return poison;
                break;

            default:
                return null;
                break;
        }
    }

}

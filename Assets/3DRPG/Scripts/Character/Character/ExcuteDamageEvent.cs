using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcuteDamageEvent : IEvent
{
    private int damage;
    private IActor actor;

    public ExcuteDamageEvent(int damage, IActor actor)
    {
        this.damage = damage;
        this.actor = actor;
    }

    public void ExcuteEvent(IActor target)
    {
        if(target != null)
        {
            if(target is PlayerStatus player)
            {

            }
            if(target is MonsterStatus monster )
            {

            }
        }
    }
}

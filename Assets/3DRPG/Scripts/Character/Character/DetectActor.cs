using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DetectActor : IDetectActor
{
    List<IActor> actors = new List<IActor>();
    public IActor closetActor { get; private set; }

    public void AddActor(IActor actor)
    {
        if(actor != null && !actors.Contains(actor))
        {
            actors.Add(actor);
        }
    }

    public void RemoveActor(IActor actor)
    {
        if (actor != null && actors.Contains(actor))
        {
            actors.Remove(actor);
        }
    }
    public void ClosetActorUpdate()
    {
        if (actors.Count > 0)
        {
            int num = Random.Range(0, actors.Count);
            closetActor= actors[num];
        }
        else
        {
            closetActor= null;
        }
    }
   
}

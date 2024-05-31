using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    Transform Transform { get; }
}
public interface IActor
{
    void ReceiveEvent(IEvent iEvent);
}
public interface IEvent
{
    void ExcuteEvent(IActor target);
}
public interface IDetectActor
{
    IActor closetActor { get; }
    void AddActor(IActor actor);
    void RemoveActor(IActor actor);
    void ClosetActorUpdate();
}

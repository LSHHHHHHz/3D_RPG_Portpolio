using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor
{
    void ReceiveEvent(IEvent iEvent);
}
public interface IEvent
{
    void ExcuteEvent(IActor target);
}

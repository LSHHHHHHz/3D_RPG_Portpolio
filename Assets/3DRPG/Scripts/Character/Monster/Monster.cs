using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public FSMController fSMController { get; private set; }
    public Animator anim { get; private set; }
    public NavMeshAgent navMesh{ get; private set; }
    DetectActor detectActor;
    protected virtual void Awake()
    {
        fSMController= GetComponent<FSMController>();
        anim = GetComponent<Animator>();     
        navMesh= GetComponent<NavMeshAgent>();
        detectActor = new DetectActor();
    }
    protected virtual void Update()
    {
        fSMController.Update();
        detectActor.ClosetActorUpdate();
    }
    public void ChangeState(IState newState)
    {
        fSMController.ChangeState(newState);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IActor target = other.GetComponent<IActor>();
            if (target != null)
            {
                detectActor.AddActor(target);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IActor target = other.GetComponent<IActor>();
            if (target != null)
            {
                detectActor.RemoveActor(target);
            }
        }
    }
}

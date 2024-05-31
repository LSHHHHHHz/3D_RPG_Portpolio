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
    public DetectActor detectActor { get; private set; }
    public IActor spawnerDetectActor { get; set; }
    public Vector3 originPos { get; private set; }
    protected virtual void Awake()
    {
        fSMController= GetComponent<FSMController>();
        anim = GetComponent<Animator>();     
        navMesh= GetComponent<NavMeshAgent>();
        detectActor = new DetectActor();
        originPos = transform.position;
    }
    protected virtual void Update()
    {
        fSMController.Update();
        detectActor.ClosetActorUpdate();
    }
    private void OnEnable()
    {
        ChangeState(new MonsterIdleState(this));
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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    public FSMController fSMController { get; private set; }
    public Animator anim { get; private set; }
    public Player player;
    public float moveSpeed = 0;
    public float rotationSpeed = 100f;
    protected virtual void Awake()
    {
        fSMController= GetComponent<FSMController>();
        anim = GetComponent<Animator>();     
    }
    protected virtual void Update()
    {
        fSMController.Update();
    }
    public void ChangeState(IState newState)
    {
        fSMController.ChangeState(newState);
    }
}

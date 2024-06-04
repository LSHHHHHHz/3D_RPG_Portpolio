using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Player player;
    public FSMController fSMController { get; private set; }
    public Animator anim { get; private set; }
    public bool checkPlayer { get; set; }
    public float moveSpeed { get; set; } = 0;
    public float rotationSpeed { get; set; } = 100f;
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

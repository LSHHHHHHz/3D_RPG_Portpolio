using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    [SerializeField] PlayerController playerController;
    int hashAttackCount = Animator.StringToHash("AttackCount");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        InputMouseButton();
        MovePlayerAnim();
        JumpPlayerAnim();
        CheckAttackState();
    }
    public void InputMouseButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack"); 
            AttackCount = 0; 
        }
    }
    private void CheckAttackState()
    {
        if(IsInAttackState())
        {
            playerController.currentSpeed = 0;
        }
    }
    private bool IsInAttackState()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName("Attack1") || stateInfo.IsName("Attack2");
    }
    public int AttackCount
    {
        get => anim.GetInteger(hashAttackCount);
        set => anim.SetInteger(hashAttackCount, value);
    }
    void MovePlayerAnim()
    {
        if (playerController.currentSpeed > 0.2f)
        {
            anim.SetBool("IsWalk", true);
        }
        else
        {
            anim.SetBool("IsWalk", false);
        }
        if (playerController.currentSpeed > 4f)
        {
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }
        // transform.LookAt(transform.position + playerController.playerMoveDir);
    }
    void JumpPlayerAnim()
    {
        if (playerController.isGround == true && Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("DoJump");
        }
        if(playerController.isGround == true)
        {
            anim.SetTrigger("DoGround");
        }
    }

}

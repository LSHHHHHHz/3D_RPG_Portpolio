using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //������
    [SerializeField] CharacterController controller;
    [SerializeField] GameObject playerRotation;
    [SerializeField] Transform camera_Point;
    [SerializeField] float currentSpeed;
    [SerializeField] float playerSpeed;
    [SerializeField] float acceleration;
    [SerializeField] float deceleration;
    [SerializeField] float turnSpeed;
    Vector2 moveInput;

    //�߷�
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float groundDistance = 0.2f;
    bool isGround;
    [SerializeField] Transform groundCheckPosition;
    [SerializeField] LayerMask groundMask;
    Vector3 velocity;
    private void Awake()
    {

    }
    private void Update()
    {
        ApplyGravity();
        KeyBoardMove();
        KeyBoardDir();
    }
    void ApplyGravity()
    {
        isGround = Physics.CheckSphere(groundCheckPosition.position, groundDistance, groundMask);
        if (!isGround)
        {
            velocity.y = gravity * Time.deltaTime;
        }
        if (velocity.y < 4f)
        {
            velocity.y = -2f;
        }
    }
    void KeyBoardMove()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        Vector3 lookForward = new Vector3(camera_Point.forward.x,0f,camera_Point.forward.z).normalized;
        Vector3 lookRight = new Vector3(camera_Point.right.x,0f,camera_Point.right.z).normalized;
        Vector3 playerMoveDir = lookForward * moveInput.y + lookRight * moveInput.x;
        Vector3 lastMoveDir = Vector3.zero;
        if(isMove)
        {
            lastMoveDir = playerMoveDir;
            currentSpeed = Mathf.Lerp(currentSpeed, playerSpeed, acceleration * Time.deltaTime);
        }
        else if(!isMove && lastMoveDir != Vector3.zero)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * deceleration);
            playerMoveDir = lastMoveDir;
        }
        controller.Move((currentSpeed * Time.deltaTime) * playerMoveDir + new Vector3(0, velocity.y, 0) * Time.deltaTime);
        if(currentSpeed <0.1f)
        {
            lastMoveDir= Vector3.zero;
        }
    }
    void KeyBoardDir()
    {
        Vector3 playerDir = moveInput.normalized;
        if(playerDir != Vector3.zero )
        {
            Vector3 forward = camera_Point.forward;
            forward.y = 0;
            forward.Normalize();
            Vector3 right = camera_Point.right;
            right.y = 0;
            right.Normalize();
            Vector3 playerMoveDirection = (forward * moveInput.y + right * moveInput.x).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(playerMoveDirection);
            playerRotation.transform.rotation = Quaternion.Slerp(playerRotation.transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
    }
}

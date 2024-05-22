using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WarePoint : MonoBehaviour
{
    [SerializeField] Transform[] warePointPos;
    Vector3 targetPos;
    float moveSpeed = 2f;
   float rotationSpeed;
    int currentIndex;
    private void Start()
    {
        targetPos = warePointPos[currentIndex].position;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        Vector3 direction = targetPos - transform.position;
        direction.y = 0; //수평회전만 하기 위해 사용
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction.normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(targetPos, transform.position) < 0.5f)
        {
            currentIndex = (currentIndex + 1) % warePointPos.Length;
            targetPos = warePointPos[currentIndex].position;
        }
    }
    public void SetMoveSpeedAndRotationSpeed(float moveSpeed, float rotationSpeed)
    {
        this.moveSpeed = moveSpeed;
        this.rotationSpeed = rotationSpeed;
    }
}

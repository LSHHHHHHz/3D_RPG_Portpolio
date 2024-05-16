using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamara : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] float cameraSpeed = 10;
    [SerializeField] float rotationSpeed = 5.0f;
    [SerializeField] float currentPitch = 0f;
    [SerializeField] float pitchRange = 30f;
    float currentAngle = 0f;
    bool keyQ;
    float elapsedTime = 0f;
    void Start()
    {
        offset = new Vector3(0, 4, 7);
    }

    void LateUpdate()
    {
        elapsedTime += Time.deltaTime;
        keyQ = Input.GetButton("CameraRotation");
        if(keyQ)
        {
            currentAngle += Input.GetAxis("Mouse X") * rotationSpeed;
            currentPitch += Input.GetAxis("Mouse Y") * rotationSpeed;
            currentPitch = Mathf.Clamp(currentPitch, -pitchRange, pitchRange);
        }
        Quaternion horizontalRotation = Quaternion.Euler(0, currentAngle, 0);
        Quaternion verticalRotation = Quaternion.Euler(currentPitch, 0, 0);
        Quaternion combinedRotation = horizontalRotation * verticalRotation;
        Vector3 rotatedOffset = combinedRotation * offset;
        if (elapsedTime <= 0.5f)
        {
            transform.position = Vector3.Lerp(transform.position, playerTransform.position + rotatedOffset, cameraSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = playerTransform.position + rotatedOffset;
        }
        transform.LookAt(playerTransform);
    }
}

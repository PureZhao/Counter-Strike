using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerCamera;
    void Awake()
    {
        playerCamera = transform.parent.Find("Camera");
    }

    void LateUpdate()
    {
        transform.localEulerAngles = playerCamera.localEulerAngles;
    }
}

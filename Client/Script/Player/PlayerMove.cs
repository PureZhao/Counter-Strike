using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 0.075f;
    public float rotateSpeed = 5f;
    public float verticalAxis = 0f;
    public float horizontalAxis = 0f;
    public Transform playerCamera;

    void Move()
    {
        if (Input.GetKey(CustomerKeys.KeyForward))
        {
            verticalAxis += Time.deltaTime * 0.1f;
            if (verticalAxis >= 1f) { verticalAxis = 1f; }
        }
        if (Input.GetKey(CustomerKeys.KeyBack)) {
            verticalAxis -= Time.deltaTime * 0.1f;
            if (verticalAxis <= -1f) { verticalAxis = -1f; }
        }
        if (!Input.GetKey(CustomerKeys.KeyForward) && !Input.GetKey(CustomerKeys.KeyBack))
        {
            verticalAxis = 0f;
        }

        if (Input.GetKey(CustomerKeys.KeyRight))
        {
            horizontalAxis += Time.deltaTime * 0.1f;
            if (horizontalAxis >= 1f) { horizontalAxis = 1f; }
        }
        if (Input.GetKey(CustomerKeys.KeyLeft))
        {
            horizontalAxis -= Time.deltaTime * 0.1f;
            if (horizontalAxis <= -1f) { horizontalAxis = -1f; }
        }
        if (!Input.GetKey(CustomerKeys.KeyLeft) && !Input.GetKey(CustomerKeys.KeyRight))
        {
            horizontalAxis = 0f;
        }
        Vector3 dir = new Vector3(horizontalAxis, 0, verticalAxis);
        transform.Translate(dir * moveSpeed, Space.Self);
    }
    void Move(float x,float y)
    {
        Vector3 dir = new Vector3(x, 0, y);
        transform.Translate(dir.normalized * moveSpeed, Space.Self);
    }
    void Rotate() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 v = new Vector3(0, mouseX * rotateSpeed, 0);
        transform.localEulerAngles += v;
        Vector3 v2 = new Vector3(-mouseY * rotateSpeed, 0, 0);
        playerCamera.localEulerAngles += v2;
    }


    void Awake()
    {
        playerCamera = transform.Find("Camera");
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float keyboardX = Input.GetAxis("Horizontal");
        float keyboardY = Input.GetAxis("Vertical");
        Move(keyboardX,keyboardY);
        Rotate();
    }


}

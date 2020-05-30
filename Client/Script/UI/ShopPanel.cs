using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{

    void OnEnable() {
        Cursor.lockState = CursorLockMode.None;
    }
    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : MonoBehaviour
{
    public Text messageText;
    public RectTransform killMessage;

    void Awake()
    {
        messageText = transform.Find("Message").GetComponent<Text>();
        killMessage = transform.Find("KillMessage").GetComponent<RectTransform>();
    }

}

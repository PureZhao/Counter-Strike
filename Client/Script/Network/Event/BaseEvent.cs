using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;

public abstract class BaseEvent : MonoBehaviour
{
    public EventCode evCode;
    public abstract void OnEvent(EventData eventData);
}

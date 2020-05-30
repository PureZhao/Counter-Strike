using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class GetDamageEvent : BaseEvent
{
    void Awake()
    {
        evCode = EventCode.Damage;
        PhotonEngine._instance.AddEvent(this);
    }

    void OnDestroy()
    {
        PhotonEngine._instance.RemoveEvent(this);
    }

    public override void OnEvent(EventData eventData)
    {
        int leftHealth = (int)PureDictTool.GetValue<byte, object>(eventData.Parameters, eventData.Code);
        PlayerDictionary.Instance.localPlayer.GetComponent<PlayerHealth>().GetDamage(leftHealth) ;
    }
}

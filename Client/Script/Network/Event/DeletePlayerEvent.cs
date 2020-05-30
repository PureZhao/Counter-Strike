using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class DeletePlayerEvent : BaseEvent
{
    void Awake()
    {
        evCode = EventCode.DeletePlayer;
        PhotonEngine._instance.AddEvent(this);
    }


    public override void OnEvent(EventData eventData)
    {
        string username = (string)PureDictTool.GetValue<byte, object>(eventData.Parameters, eventData.Code);
        PlayerDictionary.Instance.RemovePlayer(username);
    }
}

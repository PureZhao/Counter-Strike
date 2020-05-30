using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class SyncStatusEvent : BaseEvent
{
    void Awake()
    {
        evCode = EventCode.SyncStatus;
        PhotonEngine._instance.AddEvent(this);
    }

    void OnDestroy()
    {
        PhotonEngine._instance.RemoveEvent(this);
    }

    public override void OnEvent(EventData eventData)
    {
        int[] status = (int[])PureDictTool.GetValue<byte, object>(eventData.Parameters, eventData.Code);
        PanelManager.Instance.SetMember(status);

    }
}

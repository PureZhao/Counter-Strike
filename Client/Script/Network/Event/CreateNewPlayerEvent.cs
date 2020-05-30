using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class CreateNewPlayerEvent : BaseEvent
{
    void Awake()
    {
        evCode = EventCode.NewPlayer;
        PhotonEngine._instance.AddEvent(this);
    }

    void OnDestroy()
    {
        PhotonEngine._instance.RemoveEvent(this);
    }

    public override void OnEvent(EventData eventData)
    {
        string playerDataXml = (string)PureDictTool.GetValue<byte, object>(eventData.Parameters, eventData.Code);
        List<PlayerData> playerData = PureXmlTool.Deserializer<List<PlayerData>>(playerDataXml);
        foreach (PlayerData tempPlayer in playerData) {
            GameObject t = Instantiate(Prefabs.Instance.otherPlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            t.name = tempPlayer.UserName;
            PlayerDictionary.Instance.AddPlayer(tempPlayer.UserName, t);
        }
    }
}

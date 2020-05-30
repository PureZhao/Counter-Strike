using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class SyncTransformEvent : BaseEvent
{
    void Awake()
    {
        evCode = EventCode.SyncTransform;
        PhotonEngine._instance.AddEvent(this);
    }

    void OnDestroy()
    {
        PhotonEngine._instance.RemoveEvent(this);
    }

    public override void OnEvent(EventData eventData)
    {
        string playerDataListXml = (string)PureDictTool.GetValue<byte, object>(eventData.Parameters, eventData.Code);
        List<PlayerData> playerDataList = PureXmlTool.Deserializer<List<PlayerData>>(playerDataListXml);
        foreach (PlayerData tempPlayerData in playerDataList) {
            if (tempPlayerData.UserName == null) continue;
            GameObject player = (GameObject)PureDictTool.GetValue<string, GameObject>(PlayerDictionary.Instance.playerDict, tempPlayerData.UserName);
            if (player != default(GameObject))
            {
                Vector3 pos = new Vector3(tempPlayerData.Trans.PosX, tempPlayerData.Trans.PosY, tempPlayerData.Trans.PosZ);
                Vector3 rot = new Vector3(tempPlayerData.Trans.RotX, tempPlayerData.Trans.RotY, tempPlayerData.Trans.RotZ);
                player.transform.position = pos;
                player.transform.localEulerAngles = rot;
            }
        }

    }
}

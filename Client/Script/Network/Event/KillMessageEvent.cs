using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class KillMessageEvent : BaseEvent
{
    void Awake()
    {
        evCode = EventCode.KillMessage;
        PhotonEngine._instance.AddEvent(this);
    }

    void OnDestroy()
    {
        PhotonEngine._instance.RemoveEvent(this);
    }



    public override void OnEvent(EventData eventData)
    {
        string damageDataXml = (string)PureDictTool.GetValue<byte, object>(eventData.Parameters, eventData.Code);
        DamageData d = PureXmlTool.Deserializer<DamageData>(damageDataXml);
        GameObject killMessageUI = Instantiate(Prefabs.Instance.killMessagePrefab);
        killMessageUI.GetComponent<KillMessage>().SetKillMessage(d.DamageMakerName, d.Weapon.WeaponName, d.DamagedPlayerName);
        killMessageUI.GetComponent<RectTransform>().SetParent(PanelManager.Instance.messagePanel.killMessage);
        if (d.DamagedPlayerName != PlayerDictionary.Instance.localPlayer.name) {
            GameObject g = PureDictTool.GetValue<string, GameObject>(PlayerDictionary.Instance.playerDict, d.DamagedPlayerName);
            g.GetComponent<OtherPlayer>().Dead();
        }
    }
}

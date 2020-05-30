using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class DeleteDropWeaponEvent : BaseEvent
{
    void Awake()
    {
        evCode = EventCode.DeleteDropWeapon;
        PhotonEngine._instance.AddEvent(this);
    }

    void OnDestroy()
    {
        PhotonEngine._instance.RemoveEvent(this);
    }

    public override void OnEvent(EventData eventData)
    {
        string droppeItemXml = (string)PureDictTool.GetValue<byte, object>(eventData.Parameters, eventData.Code);
        DroppedItem d = PureXmlTool.Deserializer<DroppedItem>(droppeItemXml);
        GameObject dropWeaponModel = PureDictTool.GetValue<string, GameObject>(WeaponDictionary.Instance.droppedItems, d.UniqueName);
        Destroy(dropWeaponModel);
    }
}

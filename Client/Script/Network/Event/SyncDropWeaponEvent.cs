using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;
public class SyncDropWeaponEvent : BaseEvent
{
    void Awake()
    {
        evCode = EventCode.SyncDropWeapon;
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
        GameObject dropWeaponModel = Instantiate(Resources.Load("Prefab/w_Weapon/" +d.Bw.WeaponName) as GameObject);      //读取掉落武器
        DroppedWeapon temp = dropWeaponModel.GetComponent<DroppedWeapon>();         //获取丢弃武器信息脚本
        temp.SetBaseWeapon(d.Bw);       //设置武器信息]
        dropWeaponModel.transform.position = new Vector3(d.Trans.PosX, d.Trans.PosY, d.Trans.PosZ);
        WeaponDictionary.Instance.droppedItems.Add(d.UniqueName, dropWeaponModel);
    }
}

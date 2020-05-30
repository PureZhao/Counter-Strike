using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Tools;
using PureGame.Codes;

public class RequestSender : MonoBehaviour
{

    private static RequestSender _instance;

    private JoinGameRequest joinGameRequest;
    private CreateGameRequest createGameRequest;
    private TeamChooseRequest teamChooseRequest;
    private SendDamageRequest sendDamageRequest;
    private SyncDropWeaponRequest syncDropWeaponRequest;
    private DeleteDropWeaponRequest deleteDropWeaponRequest;

    void Awake() {
        _instance = this;
        joinGameRequest = GetComponent<JoinGameRequest>();
        createGameRequest = GetComponent<CreateGameRequest>();
        teamChooseRequest = GetComponent<TeamChooseRequest>();
        sendDamageRequest = GetComponent < SendDamageRequest>();
        syncDropWeaponRequest = GetComponent<SyncDropWeaponRequest>();
        deleteDropWeaponRequest = GetComponent<DeleteDropWeaponRequest>();
    }

    public void SendJoinGameRequest(string playerName) {
        OperationRequest opRequest = new OperationRequest() { Parameters = new Dictionary<byte, object>(), OperationCode = (byte)OperationCode.JoinGame };
        opRequest.Parameters.Add(opRequest.OperationCode, playerName);
        joinGameRequest.OnOperationRequest(opRequest);
    }

    public void SendCreateGameRequest(RoundSetting roundSetting) {
        string roundSettingXml = PureXmlTool.Serializer<RoundSetting>(roundSetting);
        OperationRequest opRequest = new OperationRequest() { Parameters = new Dictionary<byte, object>(), OperationCode = (byte)OperationCode.CreateGame };

        opRequest.Parameters.Add(opRequest.OperationCode, roundSettingXml);
        createGameRequest.OnOperationRequest(opRequest);
    }

    public void SendTeamChooseRequest(TeamType teamType) {
        string teamTypeXml = PureXmlTool.Serializer<TeamType>(teamType);
        OperationRequest opRequest = new OperationRequest() { Parameters = new Dictionary<byte, object>(), OperationCode = (byte)OperationCode.TeamChoose };
        opRequest.Parameters.Add(opRequest.OperationCode, teamTypeXml);
        teamChooseRequest.OnOperationRequest(opRequest);

    }

    public void SendDamageRequest(DamageData damageData) {
        string damageDataXml = PureXmlTool.Serializer<DamageData>(damageData);
        OperationRequest opRequest = new OperationRequest() { Parameters = new Dictionary<byte, object>(), OperationCode = (byte)OperationCode.Damage };
        opRequest.Parameters.Add(opRequest.OperationCode, damageDataXml);
        sendDamageRequest.OnOperationRequest(opRequest);
    }

    public void SendSyncDropWeaponRequest(DroppedWeapon droppedWeapon,Vector3 pos) {
        print(PureXmlTool.Serializer<BaseWeapon>(droppedWeapon.bw));
        DroppedItem d = new DroppedItem();
        d.UniqueName = droppedWeapon.uniqueName;
        d.Bw.BackBulletQuantity = droppedWeapon.bw.BackBulletQuantity;
        d.Bw.CurBulletQuantity = droppedWeapon.bw.CurBulletQuantity;
        d.Bw.IsHaveSpecial = droppedWeapon.bw.IsHaveSpecial;
        d.Bw.MaxBulletQuantity = droppedWeapon.bw.MaxBulletQuantity;
        d.Bw.Price = droppedWeapon.bw.Price;
        d.Bw.WeaponClass = droppedWeapon.bw.WeaponClass;
        d.Bw.WeaponName = droppedWeapon.bw.WeaponName;
        d.Trans.PosX = pos.x;
        d.Trans.PosY = pos.y;
        d.Trans.PosZ = pos.z;
        string droppedItemXml = PureXmlTool.Serializer<DroppedItem>(d);
        OperationRequest opRequest = new OperationRequest() { Parameters = new Dictionary<byte, object>(), OperationCode = (byte)OperationCode.SyncDropWeapon };
        opRequest.Parameters.Add(opRequest.OperationCode, droppedItemXml);
        syncDropWeaponRequest.OnOperationRequest(opRequest);
    }

    public void DeleteDropWeaponRequest(DroppedWeapon droppedWeapon) {
        DroppedItem d = new DroppedItem();
        d.UniqueName = droppedWeapon.uniqueName;
        d.Bw.BackBulletQuantity = droppedWeapon.bw.BackBulletQuantity;
        d.Bw.CurBulletQuantity = droppedWeapon.bw.CurBulletQuantity;
        d.Bw.IsHaveSpecial = droppedWeapon.bw.IsHaveSpecial;
        d.Bw.MaxBulletQuantity = droppedWeapon.bw.MaxBulletQuantity;
        d.Bw.Price = droppedWeapon.bw.Price;
        d.Bw.WeaponClass = droppedWeapon.bw.WeaponClass;
        d.Bw.WeaponName = droppedWeapon.bw.WeaponName;
        d.UniqueName = droppedWeapon.uniqueName;
        string droppedItemXml = PureXmlTool.Serializer<DroppedItem>(d);
        OperationRequest opRequest = new OperationRequest() { Parameters = new Dictionary<byte, object>(), OperationCode = (byte)OperationCode.DeleteDropWeapon };
        opRequest.Parameters.Add(opRequest.OperationCode, droppedItemXml);
        syncDropWeaponRequest.OnOperationRequest(opRequest);
    }







    public static RequestSender Instance
    {
        get { return RequestSender._instance; }
    }
}

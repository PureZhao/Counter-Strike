using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;
using ExitGames.Client.Photon;
public class TeamChooseRequest : BaseRequest
{
    void Awake()
    {
        opCode = OperationCode.TeamChoose;
        PhotonEngine._instance.AddRequest(this);
    }

    void OnDestroy()
    {
        PhotonEngine._instance.RemoveRequest(this);
    }

    public override void OnOperationRequest(OperationRequest operationRequest)
    {
        PhotonEngine.Peer.OpCustom(operationRequest.OperationCode, operationRequest.Parameters, true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        string selfDataXml = (string)PureDictTool.GetValue<byte,object>(operationResponse.Parameters,operationResponse.OperationCode);
        PlayerData p = PureXmlTool.Deserializer<PlayerData>(selfDataXml);
        GameObject g = Instantiate(Prefabs.Instance.localPlayerPrefab, new Vector3(Random.Range(0, 5), 0, 0), Quaternion.identity);
        g.name = p.UserName;
        g.GetComponent<PlayerStatus>().teamType = p.TeamType;
        g.GetComponent<PlayerStatus>().Respawn();
        PanelManager.Instance.messagePanel.gameObject.SetActive(true);
    }
}

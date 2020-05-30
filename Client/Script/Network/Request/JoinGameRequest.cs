using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;
using ExitGames.Client.Photon;

public class JoinGameRequest : BaseRequest
{
    void Awake()
    {
        opCode = OperationCode.JoinGame;
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
        print("Feedback");
        string mapName = (string)PureDictTool.GetValue<byte, object>(operationResponse.Parameters, operationResponse.OperationCode);
        //读取地图并且创建
        //打开玩家的选择阵营界面
        PanelManager.Instance.teamPanel.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;
using ExitGames.Client.Photon;

public class SendDamageRequest : BaseRequest
{
    void Awake()
    {
        opCode = OperationCode.Damage;
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
        
    }
}

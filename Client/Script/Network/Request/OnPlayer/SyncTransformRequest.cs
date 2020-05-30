using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class SyncTransformRequest : BaseRequest
{
    void Awake()
    {
        opCode = OperationCode.SyncTransform;
        PhotonEngine._instance.AddRequest(this);
        InvokeRepeating("UploadTransform", 1f, 1f / 24f);
    }

    void OnDestroy()
    {
        PhotonEngine._instance.RemoveRequest(this);
    }


    void UploadTransform() {
        OnOperationRequest(new OperationRequest());
    }

    public override void OnOperationRequest(OperationRequest operationRequest)
    {
        TransformData trans = new TransformData();
        trans.PosX = transform.position.x;
        trans.PosY = transform.position.y;
        trans.PosZ = transform.position.z;
        trans.RotX = transform.localEulerAngles.x;
        trans.RotY = transform.localEulerAngles.y;
        trans.RotZ = transform.localEulerAngles.z;
        string transXml = PureXmlTool.Serializer<TransformData>(trans);
        Dictionary<byte,object> transDict= new Dictionary<byte,object>();
        transDict.Add((byte)opCode,transXml);
        PhotonEngine.Peer.OpCustom((byte)opCode, transDict, true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        
    }
}

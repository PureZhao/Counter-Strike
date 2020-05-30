using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;

public abstract class BaseRequest : MonoBehaviour
{
    public OperationCode opCode;
    public abstract void OnOperationRequest(OperationRequest operationRequest);
    public abstract void OnOperationResponse(OperationResponse operationResponse);

}

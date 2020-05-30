using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;
using Photon.SocketServer;

namespace PureGameServer.Handler
{
    class JoinGameHandler : BaseHandler
    {
        public JoinGameHandler() {
            opCode = OperationCode.JoinGame;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client curClient)
        {
            string playerName = (string)PureDictTool.GetValue<byte, object>(operationRequest.Parameters, operationRequest.OperationCode);
            curClient.playerData.UserName = playerName;
            curClient.playerData.ClientStatus = ClientStatusCode.Gaming;
            curClient.playerData.GamingStatus = InGamingStatus.Stay;

            OperationResponse opResponse = new OperationResponse((byte)opCode,new Dictionary<byte,object>());
            opResponse.Parameters.Add(opResponse.OperationCode, PureGameServer._instance.RoundSetting.MapName);
            curClient.SendOperationResponse(opResponse, new SendParameters());

        }
    }
}

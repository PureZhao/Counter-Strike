using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

namespace PureGameServer.Handler
{
    public class CreateGameHandler : BaseHandler
    {
        public CreateGameHandler() {
            opCode = OperationCode.CreateGame;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client curClient)
        {
            string roundSettingXml = (string)PureDictTool.GetValue<byte, object>(operationRequest.Parameters, operationRequest.OperationCode);
            RoundSetting rs = PureXmlTool.Deserializer<RoundSetting>(roundSettingXml);
            PureGameServer._instance.RoundSetting = rs;
            curClient.playerData.UserName = rs.HostName;
            curClient.playerData.IsHost = true;
            curClient.playerData.GamingStatus = InGamingStatus.Stay;
            curClient.playerData.ClientStatus = ClientStatusCode.Gaming;

            curClient.SendOperationResponse(new OperationResponse(operationRequest.OperationCode), sendParameters);

        }
    }
}

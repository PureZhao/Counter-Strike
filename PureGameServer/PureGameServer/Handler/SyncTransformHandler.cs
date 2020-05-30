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
    class SyncTransformHandler : BaseHandler
    {
        public SyncTransformHandler() {
            opCode = OperationCode.SyncTransform;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client curClient)
        {
            string transXml = (string)PureDictTool.GetValue<byte, object>(operationRequest.Parameters, operationRequest.OperationCode);
            curClient.playerData.Trans = PureXmlTool.Deserializer<TransformData>(transXml);

            string t = PureXmlTool.Serializer<TransformData>(curClient.playerData.Trans);

        }
    }
}

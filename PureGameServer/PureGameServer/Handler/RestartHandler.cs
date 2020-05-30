using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;
using PureGameServer.Tools;

namespace PureGameServer.Handler
{
    public class RestartHandler : BaseHandler
    {

        public RestartHandler()
        {
            opCode = OperationCode.Restart;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client curClient)
        {
            foreach (Client temp in PureGameServer._instance.clientList) {
                temp.playerData.Health = 100;
            }
        }
    }
}

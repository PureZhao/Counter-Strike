using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using PureGame;
using PureGame.Codes;
namespace PureGameServer.Handler
{
    public abstract class BaseHandler
    {
        public OperationCode opCode;
        public abstract void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client curClient);
    }
}

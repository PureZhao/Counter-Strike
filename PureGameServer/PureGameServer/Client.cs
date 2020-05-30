using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using PureGameServer.Handler;
using PureGame;
using PureGame.Tools;
using PureGame.Codes;

namespace PureGameServer
{
    //代表一个客户端，由服务器自动创建
    public class Client : ClientPeer
    {
        public PlayerData playerData = new PlayerData();

        //构造函数
        public Client(InitRequest initRequest) : base(initRequest)
        {
             
        }
        //处理客户端断开连接后续工作
        protected override void OnDisconnect(PhotonHostRuntimeInterfaces.DisconnectReason reasonCode, string reasonDetail)
        {
            PureGameServer._instance.clientList.Remove(this);
            EventData ed = new EventData((byte)EventCode.DeletePlayer){Parameters = new Dictionary<byte,object>()};
            ed.Parameters.Add(ed.Code,playerData.UserName);
            foreach (Client c in PureGameServer._instance.clientList) {
                if (c != this) {
                    c.SendEvent(ed, new SendParameters());
                }
            }
        }
        //处理客户端得请求    分发Handler 请求   客户端通过OpCustom发送过来的
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            BaseHandler handler = (BaseHandler)PureDictTool.GetValue<OperationCode, BaseHandler>(PureGameServer._instance.handlerDictionary, (OperationCode)operationRequest.OperationCode);
            if (handler != null) {
                handler.OnOperationRequest(operationRequest, sendParameters, this);
            }
        }
    }
}
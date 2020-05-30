﻿using System;
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
    public class DeleteDropWeaponHandler : BaseHandler
    {
        public DeleteDropWeaponHandler() {
            opCode = OperationCode.DeleteDropWeapon;
        }


        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client curClient)
        {
            string droppedItemXml = (string)PureDictTool.GetValue<byte, object>(operationRequest.Parameters, operationRequest.OperationCode);
            EventData e = new EventData((byte)EventCode.DeleteDropWeapon) { Parameters = new Dictionary<byte, object>() };
            e.Parameters.Add(e.Code, droppedItemXml);
            foreach (Client tempClient in PureGameServer._instance.clientList)
            {
                if (tempClient != curClient)
                {
                    tempClient.SendEvent(e, new SendParameters());
                }
            }
        }
    }
}

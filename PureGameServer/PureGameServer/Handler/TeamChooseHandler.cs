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
    class TeamChooseHandler : BaseHandler
    {
        public TeamChooseHandler() {
            opCode = OperationCode.TeamChoose;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client curClient)
        {
            string teamTypeXml = (string)PureDictTool.GetValue<byte, object>(operationRequest.Parameters, operationRequest.OperationCode);
            TeamType t = PureXmlTool.Deserializer<TeamType>(teamTypeXml);
            if (t == TeamType.Red)
            {
                curClient.playerData.TeamType = TeamType.Red;
                curClient.playerData.GamingStatus = InGamingStatus.Alive;
                PureGameServer._instance.RoundSetting.RedPlayerCount++;
                PureGameServer._instance.RoundSetting.TotalPlayerCount++;
            }
            if (t == TeamType.Blue)
            {
                curClient.playerData.TeamType = TeamType.Blue;
                curClient.playerData.GamingStatus = InGamingStatus.Alive;
                PureGameServer._instance.RoundSetting.BluePlayerCount++;
                PureGameServer._instance.RoundSetting.TotalPlayerCount++;
            }


            string selfDataXml = PureXmlTool.Serializer<PlayerData>(curClient.playerData);
            //反馈消息新建玩家模型，同步其他玩家
            OperationResponse opResponse = new OperationResponse(operationRequest.OperationCode) { Parameters = new Dictionary<byte, object>() };
            opResponse.Parameters.Add(opResponse.OperationCode, selfDataXml);
            curClient.SendOperationResponse(opResponse, sendParameters);

            List<PlayerData> otherPlayer = new List<PlayerData>();
            foreach (Client tempClient in PureGameServer._instance.clientList)
            {
                if (tempClient != curClient && tempClient.playerData.GamingStatus != InGamingStatus.Stay)
                {
                    otherPlayer.Add(tempClient.playerData);
                }
            }
            if (otherPlayer.Count != 0)
            {
                EventData e = new EventData((byte)EventCode.NewPlayer) { Parameters = new Dictionary<byte, object>() };
                string otherPlayerXml = PureXmlTool.Serializer<List<PlayerData>>(otherPlayer);
                e.Parameters.Add(e.Code, otherPlayerXml);
                curClient.SendEvent(e, sendParameters);
            }
            //发送消息其他玩家同步新加入
            List<PlayerData> selfPlayer = new List<PlayerData>();
            selfPlayer.Add(curClient.playerData);
            string selfPlayerXml = PureXmlTool.Serializer<List<PlayerData>>(selfPlayer);
            EventData eOther = new EventData((byte)EventCode.NewPlayer) { Parameters = new Dictionary<byte, object>() };
            eOther.Parameters.Add(eOther.Code, selfPlayerXml);
            foreach (Client tempClient in PureGameServer._instance.clientList)
            {
                if (tempClient != curClient && tempClient.playerData.GamingStatus != InGamingStatus.Stay)
                {
                    tempClient.SendEvent(eOther, new SendParameters());
                }
            }

            //判断对局是否可以开始

        }

    }
}

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
    public class DamageHandler : BaseHandler
    {
        public DamageHandler() {
            opCode = OperationCode.Damage;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, Client curClient)
        {           
            string damageDataXml = (string)PureDictTool.GetValue<byte, object>(operationRequest.Parameters, operationRequest.OperationCode);
            DamageData damageData = PureXmlTool.Deserializer<DamageData>(damageDataXml);
            foreach (Client tempClient in PureGameServer._instance.clientList) {
                if (tempClient.playerData.UserName == damageData.DamagedPlayerName) 
                {
                    if (tempClient.playerData.TeamType == curClient.playerData.TeamType) { return; }
                    if (tempClient.playerData.Health > damageData.Damage) { tempClient.playerData.Health -= damageData.Damage; }
                    else 
                    {
                        tempClient.playerData.Health = 0;
                        tempClient.playerData.GamingStatus = InGamingStatus.Dead;
                        if (tempClient.playerData.TeamType == TeamType.Blue)
                        { 
                            PureGameServer._instance.RoundSetting.BlueAlivePlayerCount--;
                            if (PureGameServer._instance.RoundSetting.BlueAlivePlayerCount == 0)        //结束对局  红队胜
                            {
                                ProcessInfo pi = new ProcessInfo();
                                pi.IsRoundOver = true;
                                pi.WinTeam = TeamType.Red;
                                pi.ShopTime = PureGameServer._instance.RoundSetting.ShopTime;
                                string processInfoXml = PureXmlTool.Serializer<ProcessInfo>(pi);
                                EventData roundOver = Pack.EventData(EventCode.GameProcess, processInfoXml);
                                foreach (Client c in PureGameServer._instance.clientList) {
                                    c.SendEvent(roundOver, new SendParameters());
                                }
                            }
                        }

                        if (tempClient.playerData.TeamType == TeamType.Red) { 
                            PureGameServer._instance.RoundSetting.RedAlivePlayerCount--;
                            if (PureGameServer._instance.RoundSetting.BlueAlivePlayerCount == 0)//结束对局  蓝队胜
                            {
                                ProcessInfo pi = new ProcessInfo();
                                pi.IsRoundOver = true;
                                pi.WinTeam = TeamType.Blue;
                                pi.ShopTime = PureGameServer._instance.RoundSetting.ShopTime;
                                string processInfoXml = PureXmlTool.Serializer<ProcessInfo>(pi);
                                EventData roundOver = new EventData((byte)EventCode.GameProcess) { Parameters = new Dictionary<byte, object>() };
                                roundOver.Parameters.Add(roundOver.Code, processInfoXml);
                                foreach (Client c in PureGameServer._instance.clientList)
                                {
                                    c.SendEvent(roundOver, new SendParameters());
                                }
                            }
                        }
                        //发送播放动画
                        EventData ed2 = new EventData((byte)EventCode.KillMessage) { Parameters = new Dictionary<byte,object>() };
                        ed2.Parameters.Add(ed2.Code, damageDataXml);
                        foreach (Client c in PureGameServer._instance.clientList) {
                            c.SendEvent(ed2, new SendParameters());
                        }
                    }
                    //发送血量
                    EventData ed = new EventData((byte)EventCode.Damage) { Parameters = new Dictionary<byte, object>() };
                    ed.Parameters.Add(ed.Code, tempClient.playerData.Health);
                    tempClient.SendEvent(ed, new SendParameters());
                }
            }
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Photon.SocketServer;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

namespace PureGameServer.Threads
{
    public class SyncTransformThread
    {
        private Thread thread;

       public void Run() {
            thread = new Thread(SyncTransform);
            thread.IsBackground = true;
            thread.Start();
        }

        void SyncTransform() {
            Thread.Sleep(5000);

            while (true) {
                Thread.Sleep(200);
                List<PlayerData> playerDataList = new List<PlayerData>();
                foreach (Client tempClient in PureGameServer._instance.clientList)
                {
                    playerDataList.Add(tempClient.playerData);
                }
                string playerDataListXml = PureXmlTool.Serializer<List<PlayerData>>(playerDataList);
                EventData ed = new EventData((byte)EventCode.SyncTransform) {Parameters = new Dictionary<byte,object>() };
                ed.Parameters.Add(ed.Code, playerDataListXml);
                foreach (Client tempClient in PureGameServer._instance.clientList)
                {
                    tempClient.SendEvent(ed, new SendParameters());
                }
            }
        }
       public void Stop() {
            thread.Abort();
        }

    }
}

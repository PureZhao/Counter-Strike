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
    public class SyncStatusThread
    {
        private Thread thread;

        public void Run()
        {
            thread = new Thread(UpdateStatus);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Stop()
        {
            thread.Abort();
        }

        void UpdateStatus()
        {
            Thread.Sleep(5000);

            while (true)
            {
                Thread.Sleep(500);
                int[] clientStatus = new int[2] { 0, 0 };
                foreach (Client tempClient in PureGameServer._instance.clientList)
                {
                    if (tempClient.playerData.ClientStatus == ClientStatusCode.Hanging) clientStatus[0]++;
                    if (tempClient.playerData.ClientStatus == ClientStatusCode.Gaming) clientStatus[1]++;
                }
                Dictionary<byte, object> data = new Dictionary<byte, object>();
                data.Add((byte)EventCode.SyncStatus, clientStatus);
                foreach (Client tempClient in PureGameServer._instance.clientList)
                {
                    EventData eventData = new EventData((byte)EventCode.SyncStatus);
                    eventData.SetParameters(data);
                    tempClient.SendEvent(eventData, new SendParameters());
                }


            }
        }
    }
}

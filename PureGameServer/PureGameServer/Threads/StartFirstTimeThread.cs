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
using PureGameServer.Tools;

namespace PureGameServer.Threads
{
    public class StartFirstTimeThread
    {
        private Thread thread;

        public void Run()
        {
            thread = new Thread(Detect);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Stop()
        {
            thread.Abort();
        }

        void Detect()
        {
            while (true)
            {
                Thread.Sleep(200);
                if (PureGameServer._instance.RoundSetting.RedPlayerCount == 1 && PureGameServer._instance.RoundSetting.BluePlayerCount == 1) {
                    //发送消息开始第一次
                    ProcessInfo p = Pack.GameStart();
                    p.IsFirstStart = true;
                    p.Money = 800;
                    string pXml = PureXmlTool.Serializer<ProcessInfo>(p);
                    EventData e = Pack.EventData(EventCode.GameProcess, pXml);
                    foreach (Client c in PureGameServer._instance.clientList) {
                        c.SendEvent(e, new SendParameters());
                    }
                    break;

                }


            }
            thread.Abort();
        }




    }
}

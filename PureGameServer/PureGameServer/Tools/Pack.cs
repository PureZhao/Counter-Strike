using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PureGame;
using PureGame.Tools;
using PureGame.Codes;
using Photon.SocketServer;

namespace PureGameServer.Tools
{
    public class Pack
    {
        public static OperationResponse Response(OperationCode code, string xml) {
            OperationResponse opResponse = new OperationResponse((byte)code) { Parameters = new Dictionary<byte, object>() };
            opResponse.Parameters.Add(opResponse.OperationCode, xml);
            return opResponse;
        }

        public static EventData EventData(EventCode code, string xml)
        {
            EventData eventData = new EventData((byte)code) { Parameters = new Dictionary<byte, object>() };
            eventData.Parameters.Add(eventData.Code, xml);
            return eventData;
        }

        public static ProcessInfo GameStart() {
            ProcessInfo p = new ProcessInfo();
            p.IsRoundOver = false;
            p.Set(PureGameServer._instance.RoundSetting);
            return p;
        }
        public static ProcessInfo GameOver() {
            ProcessInfo p = new ProcessInfo();
            p.IsRoundOver = true;
            p.Set(PureGameServer._instance.RoundSetting);
            return p;
        }

    }
}

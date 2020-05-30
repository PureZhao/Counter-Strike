using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class GameProcessEvent : BaseEvent
{
    void Awake()
    {
        evCode = EventCode.GameProcess;
        PhotonEngine._instance.AddEvent(this);
    }

    void OnDestroy()
    {
        PhotonEngine._instance.RemoveEvent(this);
    }

    public override void OnEvent(EventData eventData)
    {
        string processInfoXml = (string)PureDictTool.GetValue<byte, object>(eventData.Parameters, eventData.Code);
        ProcessInfo p = PureXmlTool.Deserializer<ProcessInfo>(processInfoXml);
        //第一次开始游戏
        if (p.IsFirstStart) {
            GameManager.Instance.OnGameFirstStart(p);
        }

        if (p.IsRoundOver)  //回合结束
        {
            if (p.WinTeam == TeamType.Blue) 
            {
                AudioSource.PlayClipAtPoint(Audios.Instance.blueWin, Vector3.zero);               
            }
            if (p.WinTeam == TeamType.Red)
            {
                AudioSource.PlayClipAtPoint(Audios.Instance.redWin, Vector3.zero);
            }
            GameManager.Instance.OnRoundOver(p);
        }
    }
}

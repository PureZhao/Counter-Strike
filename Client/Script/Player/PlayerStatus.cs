using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class PlayerStatus : MonoBehaviour
{

    public int money = 0;
    public TeamType teamType;
    public bool isLocalPlayer = true;

    public void AddMoney(int val) {
        money += val;
        if (money > 1600) { money = 16000; }
        //更改UI
        PanelManager.Instance.playerInfoPanel.SetMoney(money);
    }
    public bool MinusMoney(int val) {
        if (money >= val) {
            money -= val;
            PanelManager.Instance.playerInfoPanel.SetMoney(money);
            return true;
            }
        return false;
    }

    public void Respawn() {
        Transform map = GameObject.FindGameObjectWithTag("Map").transform;
        if (teamType == TeamType.Blue) {
            transform.position = map.Find("BlueArea/RespawnPoint").position;
        }
        if (teamType == TeamType.Red)
        {
            transform.position = map.Find("RedArea/RespawnPoint").position;
        }
    }

    void Awake() {

    }

}

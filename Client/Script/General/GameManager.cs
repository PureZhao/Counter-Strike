using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;
public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public void OnGameFirstStart(ProcessInfo p){
        WeaponDictionary.Instance.ClearDropItem();
        PlayerDictionary.Instance.localPlayer.GetComponent<PlayerStatus>().AddMoney(p.Money);
        PlayerDictionary.Instance.localPlayer.GetComponent<PlayerStatus>().Respawn();
        PlayerDictionary.Instance.localPlayer.GetComponent<PlayerUI>().ShopTime((int)p.ShopTime);
    }

    public void OnRoundOver(ProcessInfo p)
    {
        WeaponDictionary.Instance.ClearDropItem();          //清除地图上的掉落物
        StartCoroutine(RoundOver(p));
    }


    IEnumerator RoundOver(ProcessInfo p)
    {
        yield return new WaitForSeconds(5f); 
        //重置玩家
        PlayerDictionary.Instance.localPlayer.SetActive(true);
        PlayerDictionary.Instance.localPlayer.GetComponent<PlayerStatus>().AddMoney(p.Money);
        PlayerDictionary.Instance.localPlayer.GetComponent<PlayerStatus>().Respawn();
        PanelManager.Instance.playerInfoPanel.GetComponent<PlayerInfoPanel>().healthValueText.text = "100";
        PanelManager.Instance.playerInfoPanel.GetComponent<PlayerInfoPanel>().kevlarValueText.text = "100";
        PlayerDictionary.Instance.localPlayer.GetComponent<PlayerUI>().ShopTime((int)p.ShopTime);
        PhotonEngine.Peer.OpCustom((byte)OperationCode.Restart, new Dictionary<byte, object>(), true);
    }
    void Awake()
    {
        instance = this;
    }


    public static GameManager Instance
    {
        get { return GameManager.instance; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    private static PanelManager instance;
    public StartPanel startPanel;
    public NewGamePanel newGamePanel;
    public JoinGamePanel joinGamePanel;
    public SettingPanel settingPanel;
    public ExitPanel exitPanel;
    public MessagePanel messagePanel;
    public PlayerInfoPanel playerInfoPanel;
    public TeamPanel teamPanel;
    public Transform shopPanel;

    public int hangingMember;
    public int inGamingMember;
    public Text curHangingText;
    public Text curInGamingText;
    public void SetMember(int[] a){
        hangingMember = a[0];
        inGamingMember = a[1];
        curHangingText.text = "当前在线人数：" + hangingMember.ToString();
        curInGamingText.text = "游戏中人数：" + inGamingMember.ToString();
    }



    void Awake() {
        instance = this;
        startPanel = transform.Find("PanelStart").GetComponent<StartPanel>();
        newGamePanel = transform.Find("PanelNewGame").GetComponent<NewGamePanel>();
        joinGamePanel = transform.Find("PanelJoinGame").GetComponent<JoinGamePanel>() ;
        settingPanel = transform.Find("PanelSetting").GetComponent<SettingPanel>();
        exitPanel = transform.Find("PanelExit").GetComponent<ExitPanel>() ;
        messagePanel = transform.Find("PanelMessage").GetComponent<MessagePanel>();
        playerInfoPanel = transform.Find("PanelPlayerInfo").GetComponent<PlayerInfoPanel>();
        teamPanel = transform.Find("PanelTeam").GetComponent<TeamPanel>();
        shopPanel = transform.Find("PanelShop");

        curHangingText = transform.Find("CurHanging").GetComponent<Text>();
        curInGamingText = transform.Find("CurInGaming").GetComponent<Text>();
    }



    public static PanelManager Instance
    {
        get { return PanelManager.instance; }
    }
}

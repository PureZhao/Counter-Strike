using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class NewGamePanel : MonoBehaviour
{
    public InputField playerNameInput;
    public InputField shopTimeInput;
    public InputField startMoneyInput;
    public Text mapNameText;

    void Awake() {
        playerNameInput = transform.Find("SettingContent/PlayerNameInput").GetComponent<InputField>();
        shopTimeInput = transform.Find("SettingContent/ShopTimeInput").GetComponent<InputField>();
        startMoneyInput = transform.Find("SettingContent/StartMoneyInput").GetComponent<InputField>();
        mapNameText = transform.Find("MapSelect/Label").GetComponent<Text>();

        transform.Find("StartButton").GetComponent<Button>().onClick.AddListener(OnStartClick);
        transform.Find("CancelButton").GetComponent<Button>().onClick.AddListener(OnCancelClick);

        

    }


    void OnStartClick() {
        if (PanelManager.Instance.inGamingMember != 0)
        {
           GameObject g = Instantiate(Resources.Load("Prefab/UI/TipMessage") as GameObject, PanelManager.Instance.GetComponent<RectTransform>());
           g.GetComponent<FloatTipMessage>().SetText("请直接加入游戏");
            return;
        }
        //将上述信息传递至服务器，关闭其他玩家新建游戏按钮
        RoundSetting rs = new RoundSetting();
        rs.ShopTime = float.Parse(shopTimeInput.text);
        rs.StartMoney = int.Parse(startMoneyInput.text);
        rs.MapName = mapNameText.text;
        rs.HostName = playerNameInput.text;
        RequestSender.Instance.SendCreateGameRequest(rs);
        PanelManager.Instance.newGamePanel.gameObject.SetActive(false);
    }

    void OnCancelClick() {
        PanelManager.Instance.newGamePanel.gameObject.SetActive(false);
        PanelManager.Instance.startPanel.gameObject.SetActive(true);
    }
}

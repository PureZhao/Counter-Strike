using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class JoinGamePanel : MonoBehaviour
{
    public InputField playerNameInput;
    void Awake()
    {
        playerNameInput =transform.Find("PlayerNameInput").GetComponent<InputField>();
        transform.Find("ComfirmButton").GetComponent<Button>().onClick.AddListener(OnConfirmClick);
        transform.Find("CancelButton").GetComponent<Button>().onClick.AddListener(OnCancelClick);
    }

    void OnConfirmClick() {
        if (playerNameInput.text.Trim() == null) {
            GameObject g = Instantiate(Resources.Load("Prefab/UI/TipMessage") as GameObject, PanelManager.Instance.GetComponent<RectTransform>());
            g.GetComponent<FloatTipMessage>().SetText("玩家名字不能为空和空格");
            return;
        }
        if (PanelManager.Instance.inGamingMember == 0) {
            GameObject g = Instantiate(Resources.Load("Prefab/UI/TipMessage") as GameObject, PanelManager.Instance.GetComponent<RectTransform>());
            g.GetComponent<FloatTipMessage>().SetText("请先创建游戏");
            return;
        }
        PanelManager.Instance.joinGamePanel.gameObject.SetActive(false);
        //发送服务器
        RequestSender.Instance.SendJoinGameRequest(playerNameInput.text.Trim());
    }

    void OnCancelClick() {
        PanelManager.Instance.startPanel.gameObject.SetActive(true);
        PanelManager.Instance.joinGamePanel.gameObject.SetActive(false);
    }
}

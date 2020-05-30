using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{


    void Awake()
    {
        transform.Find("NewGame").GetComponent<Button>().onClick.AddListener(OnNewGameClick);
        transform.Find("JoinGame").GetComponent<Button>().onClick.AddListener(OnJoinGameClick);
        transform.Find("Setting").GetComponent<Button>().onClick.AddListener(OnSettingClick);
        transform.Find("Exit").GetComponent<Button>().onClick.AddListener(OnExitClick);

    }

    void OnNewGameClick() {
        PanelManager.Instance.newGamePanel.gameObject.SetActive(true);
        PanelManager.Instance.startPanel.gameObject.SetActive(false);
    }

    void OnJoinGameClick() {
        if (PanelManager.Instance.inGamingMember == 0)
        {
            GameObject g = Instantiate(Resources.Load("Prefab/UI/TipMessage") as GameObject, PanelManager.Instance.GetComponent<RectTransform>());
            g.GetComponent<FloatTipMessage>().SetText("请新建游戏");
            return;
        }
        PanelManager.Instance.startPanel.gameObject.SetActive(false);
        PanelManager.Instance.joinGamePanel.gameObject.SetActive(true);
    }

    void OnSettingClick() {
        PanelManager.Instance.startPanel.gameObject.SetActive(false);
        PanelManager.Instance.settingPanel.gameObject.SetActive(true);
    }
    void OnExitClick() {
        PanelManager.Instance.startPanel.gameObject.SetActive(false);
        PanelManager.Instance.exitPanel.gameObject.SetActive(true);
    }
}

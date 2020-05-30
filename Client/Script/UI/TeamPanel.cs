using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureGame.Codes;
using ExitGames.Client.Photon;

public class TeamPanel : MonoBehaviour
{
   
    void Awake()
    {
        transform.Find("Red").GetComponentInChildren<Button>().onClick.AddListener(OnRedClick);
        transform.Find("Blue").GetComponentInChildren<Button>().onClick.AddListener(OnBlueClick);
    }

    void OnRedClick() {
        RequestSender.Instance.SendTeamChooseRequest(TeamType.Red);
        PanelManager.Instance.playerInfoPanel.gameObject.SetActive(true);
        PanelManager.Instance.teamPanel.gameObject.SetActive(false);
    }

    void OnBlueClick() {
        RequestSender.Instance.SendTeamChooseRequest(TeamType.Blue);
        PanelManager.Instance.playerInfoPanel.gameObject.SetActive(true);
        PanelManager.Instance.teamPanel.gameObject.SetActive(false);
    }
}

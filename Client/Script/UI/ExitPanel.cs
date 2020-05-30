using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitPanel : MonoBehaviour
{

    void Awake()
    {
        transform.Find("ComfirmButton").GetComponent<Button>().onClick.AddListener(OnConfirmClick);
        transform.Find("CancelButton").GetComponent<Button>().onClick.AddListener(OnCancelClick);
    }

    void OnConfirmClick() {
        Application.Quit();
    }

    void OnCancelClick() {
        PanelManager.Instance.startPanel.gameObject.SetActive(true);
        PanelManager.Instance.exitPanel.gameObject.SetActive(false);
    }
}

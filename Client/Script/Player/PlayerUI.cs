using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public int shopTime = 15;

    public void ShopTime(int time) {
        shopTime = time;
        //StartCoroutine(ShopTimeRun());
    }
    IEnumerator ShopTimeRun() {
        while (shopTime != 0) {
            yield return new WaitForSeconds(1f);
            shopTime--;
        }
    }

    void UIControl()
    {
        if (Input.GetKeyDown(KeyCode.B) && shopTime > 0f)
        {
            if (!PanelManager.Instance.shopPanel.gameObject.activeSelf)
            {
                PanelManager.Instance.shopPanel.gameObject.SetActive(true);
            }
            else
            {
                PanelManager.Instance.shopPanel.gameObject.SetActive(false);
            }
        }
    }

    void Awake()
    {
        
    }

    void Update()
    {
        UIControl();
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int kevlar = 0;

    public void GetDamage(int val) {
        print(val);
        if (val > 0) {
            PanelManager.Instance.playerInfoPanel.SetHealth(val);
            print("还活着");
            //更新UI
        }
        else {
            PanelManager.Instance.playerInfoPanel.SetHealth(val);
            print("死了");
            //调用死亡处理
            Instantiate(Prefabs.Instance.deadModel, transform.position + transform.forward * 10, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }


    void OnDead() {
        
    }

    void Awake()
    {
        PlayerDictionary.Instance.localPlayer = this.gameObject;
    }

}

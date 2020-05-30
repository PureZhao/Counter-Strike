using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using PureGame;
using PureGame.Tools;
public class PointerAction : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    //鼠标悬浮
    public void OnPointerEnter(PointerEventData eventData) {
        string thisWeaponName = gameObject.name;
        Sprite thisWeaponImage = Resources.Load("Image/Shop/" + thisWeaponName, typeof(Sprite)) as Sprite;
        Image temp = transform.parent.parent.Find("DisplayArea/Image").GetComponent<Image>();
        temp.sprite = thisWeaponImage;
        temp.color = new Color(1, 1, 1, 1);
        BaseWeapon b = PureDictTool.GetValue<string, BaseWeapon>(WeaponDictionary.Instance.weaponDict, thisWeaponName);
        transform.parent.parent.Find("DisplayArea/Price").GetComponent<Text>().text = "$" + b.Price.ToString();
    }
    //鼠标退出
    public void OnPointerExit(PointerEventData eventData) {
        Image temp = transform.parent.parent.Find("DisplayArea/Image").GetComponent<Image>();
        temp.sprite = null;
        temp.color = new Color(1, 1, 1, 0);
        transform.parent.parent.Find("DisplayArea/Price").GetComponent<Text>().text = "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BaseWeapon bw = (BaseWeapon)PureDictTool.GetValue<string, BaseWeapon>(WeaponDictionary.Instance.weaponDict, gameObject.name);
        PlayerDictionary.Instance.localPlayer.GetComponent<PlayerWeapon>().GetWeapon(bw);
        PanelManager.Instance.shopPanel.gameObject.SetActive(false);
    }
}

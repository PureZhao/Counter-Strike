using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PureGame;
using PureGame.Codes;

public class PlayerInfoPanel : MonoBehaviour
{
    public Text healthValueText;
    public Text kevlarValueText;
    public Text bulletValueText;
    public Text moneyValueText;
    public Image[] weaponImage = new Image[5];

    void Awake()
    {
        healthValueText = transform.Find("Health").GetComponentInChildren<Text>();
        kevlarValueText = transform.Find("Kevlar").GetComponentInChildren<Text>();
        bulletValueText = transform.Find("Bullet").GetComponentInChildren<Text>();
        moneyValueText = transform.Find("Money").GetComponentInChildren<Text>();
        weaponImage[0] = transform.Find("Arm/Rifle").GetComponentInChildren<Image>();
        weaponImage[1] = transform.Find("Arm/Pistol").GetComponentInChildren<Image>();
        weaponImage[2] = transform.Find("Arm/Knife").GetComponentInChildren<Image>();
        weaponImage[3] = transform.Find("Arm/Grenade").GetComponentInChildren<Image>();
        weaponImage[4] = transform.Find("Arm/Bomb").GetComponentInChildren<Image>();
    }

    public void SetWeaponImage(BaseWeapon bw)
    {
        Sprite s = Resources.Load("Image/Catoon/" + bw.WeaponName,typeof(Sprite)) as Sprite;
        if (bw.WeaponClass == WeaponType.Rifle) { weaponImage[0].sprite= s; }
        if (bw.WeaponClass == WeaponType.Pistol) { weaponImage[1].sprite = s; }
        if (bw.WeaponClass == WeaponType.Knife) { weaponImage[2].sprite = s; }
        if (bw.WeaponClass == WeaponType.Grenade) { weaponImage[3].sprite = s; }
        if (bw.WeaponClass == WeaponType.Bomb) { weaponImage[4].sprite = s; }
    }
    public void WeaponSwitch(BaseWeapon from,BaseWeapon to) {
        switch (to.WeaponClass) {
            case WeaponType.Rifle: weaponImage[0].color = Color.white; break;
            case WeaponType.Pistol: weaponImage[1].color = Color.white; break;
            case WeaponType.Knife: weaponImage[2].color = Color.white; break;
            case WeaponType.Grenade: weaponImage[3].color = Color.white; break;
            case WeaponType.Bomb: weaponImage[4].color = Color.white; break;
        }
        switch (from.WeaponClass)
        {
            case WeaponType.Rifle: weaponImage[0].color = Color.grey; break;
            case WeaponType.Pistol: weaponImage[1].color = Color.grey; break;
            case WeaponType.Knife: weaponImage[2].color = Color.grey; break;
            case WeaponType.Grenade: weaponImage[3].color = Color.grey; break;
            case WeaponType.Bomb: weaponImage[4].color = Color.grey; break;
        }
    }
    public void OnWeaponLose(BaseWeapon bw) {
        switch (bw.WeaponClass)
        {
            case WeaponType.Rifle: weaponImage[0].color = Color.clear; break;
            case WeaponType.Pistol: weaponImage[1].color = Color.clear; break;
            case WeaponType.Knife: weaponImage[2].color = Color.clear; break;
            case WeaponType.Grenade: weaponImage[3].color = Color.clear; break;
            case WeaponType.Bomb: weaponImage[4].color = Color.clear; break;
        }
    }
    public void SetHealth(int leftHealth) {
        int hp = int.Parse(healthValueText.text) - leftHealth;
        kevlarValueText.text = (int.Parse(kevlarValueText.text) - hp / 5).ToString();
        healthValueText.text = leftHealth.ToString();

    }
    public void SetKevlar(int leftKevlar) {
        kevlarValueText.text = leftKevlar.ToString();
    }
    public void SetMoney(int leftMoney) { 
        moneyValueText.text = "$ "+ leftMoney.ToString();
    }
    public void SetBullet(int cur, int back) {
        if (cur >= 0 || back >= 0)
            bulletValueText.text = cur.ToString() + "/" + back.ToString();
        else
            bulletValueText.text = "";
    }
}

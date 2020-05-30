using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;
using UnityEngine;
using PureGame;
using PureGame.Codes;

public class WeaponDictionary : MonoBehaviour
{
    private static WeaponDictionary instance;

    public Dictionary<string, BaseWeapon> weaponDict = new Dictionary<string, BaseWeapon>();
    public Dictionary<string, GameObject> droppedItems = new Dictionary<string, GameObject>();

    public void ClearDropItem() {
        foreach (GameObject g in droppedItems.Values) {
            Destroy(g);
        }
        droppedItems.Clear();
    }

    void Awake() {
        instance = this;
        string allWeapon = (Resources.Load("Text/WeaponInfo") as TextAsset).text;
        string[] perWeapon = allWeapon.Split('\n');
        foreach (string temp in perWeapon) {
            BaseWeapon b = new BaseWeapon(); 
            string[] t = temp.Split(',');
            b.WeaponName = t[0];
            b.WeaponClass = (WeaponType)Enum.Parse(typeof(WeaponType), t[1]);
            if (t[2] != "U/N") { b.Price = int.Parse(t[2]); }
            if (t[3] != "U/N") { b.MaxBulletQuantity = int.Parse(t[3]); b.CurBulletQuantity = b.MaxBulletQuantity; }
            if (t[4] != "U/N") { b.BackBulletQuantity = int.Parse(t[4]); b.MaxBackbackBulletQuantity = b.BackBulletQuantity; }
            b.IsHaveSpecial = bool.Parse(t[5]);
            weaponDict.Add(t[0], b);
        }
    }



    public static WeaponDictionary Instance
    {
        get { return WeaponDictionary.instance; }
    }
}

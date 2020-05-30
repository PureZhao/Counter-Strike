using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class DroppedWeapon : MonoBehaviour
{
    public Vector3 throwDir;
    public string uniqueName;
    public BaseWeapon bw = new BaseWeapon();

    public void SetBaseWeapon(BaseWeapon baseWeapon) {
        bw = new BaseWeapon();
        bw.WeaponName = baseWeapon.WeaponName;
        bw.WeaponClass = baseWeapon.WeaponClass;
        bw.Price = baseWeapon.Price;
        bw.MaxBulletQuantity = baseWeapon.MaxBulletQuantity;
        bw.IsHaveSpecial = baseWeapon.IsHaveSpecial;
        bw.CurBulletQuantity = baseWeapon.CurBulletQuantity;
        bw.BackBulletQuantity = baseWeapon.BackBulletQuantity;
    }
    public string GetUniqueName() {
        Head:
        while (true)
        {
            string id = Random.Range(0, int.MaxValue).ToString();
            foreach (string tempId in WeaponDictionary.Instance.droppedItems.Keys)
            {
                if (tempId == id) {goto Head; }
            }
            return id;
        }
    }
    void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "LocalPlayer")
        {
            PlayerWeapon pw = other.transform.GetComponent<PlayerWeapon>();
            int i = PureTranslateTool.WeaponTypeToInt(bw.WeaponClass);
            if (pw.isHaveWeapon[i]) { return; }
            pw.GetWeapon(bw);
            //发送消息删除该掉落
            RequestSender.Instance.DeleteDropWeaponRequest(this);
            Destroy(gameObject);
        }
    }

    void Awake() {
        uniqueName = GetUniqueName();
        
        WeaponDictionary.Instance.droppedItems.Add(uniqueName,gameObject);
    }
    void Start() { GetComponent<Rigidbody>().AddForce(throwDir * 400f); }
    void OnDestroy() {
        WeaponDictionary.Instance.droppedItems.Remove(uniqueName);
    }

}

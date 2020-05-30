using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class PlayerWeapon : MonoBehaviour
{
    public WeaponType curWeapon = WeaponType.Knife;        //当前武器
    public WeaponType lastWeapon = WeaponType.None;           //上一个武器           
    public Transform[] weaponPostion = new Transform[5];           //武器生成位置
    public Weapon[] weapon = new Weapon[5];                //武器控制脚本
    public bool[] isHaveWeapon = new bool[5] { false, false, true, false, false };         //是否有该武器
    public bool isShootReady = true;                //开火准备
    /* 武器控制动画 */
    //射击与特殊控制
    void TrueShootReady() { isShootReady = true; }
    void FalseShootReady() { isShootReady = false; }
    void ShootAndSpecial() {
        if (Input.GetKey(KeyCode.Mouse0) && isShootReady) 
        {
            if (curWeapon == WeaponType.Rifle) { weapon[0].Shoot(curWeapon); }
            if (curWeapon == WeaponType.Grenade) { weapon[3].Shoot(curWeapon); }
            if (curWeapon == WeaponType.Bomb) { weapon[4].Shoot(curWeapon); }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && isShootReady)
        {
            if (curWeapon == WeaponType.Pistol) { weapon[1].Shoot(curWeapon); }
            if (curWeapon == WeaponType.Knife) { weapon[2].Shoot(curWeapon); }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && isShootReady)
        {
            if (curWeapon == WeaponType.Grenade) { weapon[3].Shoot(curWeapon,true); }
        }
    }
    //换弹
    void Relaod() {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (curWeapon == WeaponType.Rifle) { weapon[0].Reload(); }
            if (curWeapon == WeaponType.Pistol) { weapon[1].Reload(); }
        }
    }
    //切换武器
    void SwitchWeapon()
    {
        int curWeaponNum = PureTranslateTool.WeaponTypeToInt(curWeapon);
        int lastWeaponNum = PureTranslateTool.WeaponTypeToInt(lastWeapon);
        if (Input.GetKeyDown(KeyCode.Alpha1) && isHaveWeapon[0] && curWeapon != WeaponType.Rifle)
        {
            OnWeaponChange(weapon[curWeaponNum], weapon[0], weaponPostion[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isHaveWeapon[1] && curWeapon != WeaponType.Pistol)
        {
            OnWeaponChange(weapon[curWeaponNum], weapon[1], weaponPostion[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && isHaveWeapon[2] && curWeapon != WeaponType.Knife)
        {
            OnWeaponChange(weapon[curWeaponNum], weapon[2], weaponPostion[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && isHaveWeapon[3] && curWeapon != WeaponType.Grenade)
        {
            OnWeaponChange(weapon[curWeaponNum], weapon[3], weaponPostion[3]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && isHaveWeapon[4] && curWeapon != WeaponType.Bomb)
        {
            OnWeaponChange(weapon[curWeaponNum], weapon[4], weaponPostion[4]);
        }
        if (Input.GetKeyDown(KeyCode.Q) && lastWeapon != WeaponType.None)
        {
            OnWeaponChange(weapon[curWeaponNum], weapon[lastWeaponNum], weaponPostion[lastWeaponNum]);
        }
    }
    //丢弃武器
    void DropWeapon()
    {
        if (Input.GetKeyDown(KeyCode.G) && (curWeapon == WeaponType.Rifle || curWeapon == WeaponType.Pistol || curWeapon == WeaponType.Bomb))
        {
            int i = PureTranslateTool.WeaponTypeToInt(curWeapon);
            GameObject dropWeaponModel = Instantiate(Resources.Load("Prefab/w_Weapon/" + weapon[i].bw.WeaponName) as GameObject);      //读取掉落武器
            DroppedWeapon temp = dropWeaponModel.GetComponent<DroppedWeapon>();         //获取丢弃武器信息脚本
            temp.throwDir = transform.forward;
            temp.SetBaseWeapon(weapon[i].bw);       //设置武器信息]
            PanelManager.Instance.playerInfoPanel.OnWeaponLose(temp.bw);            //更新UI
            dropWeaponModel.transform.position = transform.localPosition + transform.forward * 2f;
            RequestSender.Instance.SendSyncDropWeaponRequest(temp, dropWeaponModel.transform.position);         //向服务器发送
            Destroy(weapon[i].gameObject);         //销毁扔掉的武器
            weaponPostion[i].gameObject.SetActive(false);          //关闭武器点
            isHaveWeapon[i] = false;                //标识武器没有了
            BIndWeaponControl();                //更新武器控制脚本
            //查找第一个还有的武器并切换出来
            SwitchFirstHave();
        }
    }

    void OnBombPlanted() {
        Destroy(weapon[4].gameObject);
        weaponPostion[4].gameObject.SetActive(false);
        isHaveWeapon[4] = false;
        BIndWeaponControl();
        SwitchFirstHave();
    }
    void OnGrenadeThrew() {
        Destroy(weapon[3].gameObject);
        weaponPostion[3].gameObject.SetActive(false);
        isHaveWeapon[3] = false;
        BIndWeaponControl();
        SwitchFirstHave();
    }
    //获得武器
    public void GetWeapon(BaseWeapon baseWeapon)
    {
        int i = PureTranslateTool.WeaponTypeToInt(baseWeapon.WeaponClass);
        if (isHaveWeapon[i]) return;            //已经有该类型武器不继续获得
        int j = PureTranslateTool.WeaponTypeToInt(curWeapon);
        GameObject weaponPrefab = Resources.Load("Prefab/v_Weapon/" + baseWeapon.WeaponName) as GameObject;
        GameObject newWeapon = GameObject.Instantiate(weaponPrefab, weaponPostion[i].position, Quaternion.identity);
        Weapon w = newWeapon.GetComponent<Weapon>();
        w.SetBaseWeapon(baseWeapon);
        PanelManager.Instance.playerInfoPanel.SetWeaponImage(w.bw);     //改变UI
        newWeapon.transform.SetParent(weaponPostion[i]);   //设置位置
        newWeapon.transform.localEulerAngles = Vector3.zero;
        isHaveWeapon[i] = true;             //      标记已有
        BIndWeaponControl();            //绑定控制脚本
        OnWeaponChange(weapon[j], weapon[i], weaponPostion[i]);
    }
    //绑定武器控制脚本
    void SwitchFirstHave()
    {
        for (int j = 0; j < 4; j++)
        {
            if (isHaveWeapon[j])
            {
                Weapon noneWeapon = new Weapon();
                noneWeapon.bw.WeaponClass = WeaponType.None;
                OnWeaponChange(noneWeapon, weapon[j], weaponPostion[j]);
                return;
            }
        }
    }
    void BIndWeaponControl()
    {
        for (int i = 0; i < 5; i++)
        {
            if (isHaveWeapon[i])
            {
                weapon[i] = weaponPostion[i].GetComponentInChildren<Weapon>();
            }
        }
    }
    void OnWeaponChange(Weapon from, Weapon to, Transform toTrans)
    {
        foreach (Transform t in weaponPostion) { t.gameObject.SetActive(false); }
        lastWeapon = from.bw.WeaponClass;
        curWeapon = to.bw.WeaponClass;
        toTrans.gameObject.SetActive(true);
        PanelManager.Instance.playerInfoPanel.WeaponSwitch(from.bw, to.bw);
    }
    public void BulletRecovery() {
        for (int j = 0; j < 4; j++)
        {
            if (isHaveWeapon[j])
            {
                weapon[j].bw.CurBulletQuantity = weapon[j].bw.MaxBulletQuantity;
                weapon[j].bw.BackBulletQuantity = weapon[j].bw.MaxBackbackBulletQuantity;
            }
        }
    }
    public void CloseAllWeapon() {
        foreach (Transform t in weaponPostion) {
            t.gameObject.SetActive(false);
        }
    }
    void OnDisable() {
        curWeapon = WeaponType.Knife;
        lastWeapon = WeaponType.None;  
        foreach(Transform t in weaponPostion){
            if (t.name == "Knife") continue;
            if (t.GetChildCount() != 0) {
                Destroy(t.GetChild(0));
                t.gameObject.SetActive(false);
            }
        }
        weaponPostion[2].gameObject.SetActive(true);
        isHaveWeapon = new bool[5] { false, false, true, false, false };
        isShootReady = true;                //开火准备
        BIndWeaponControl();
    }
    void Awake()
    {

        weaponPostion[0] = transform.Find("Rifle");
        weaponPostion[1] = transform.Find("Pistol");
        weaponPostion[2] = transform.Find("Knife");
        weaponPostion[3] = transform.Find("Grenade");
        weaponPostion[4] = transform.Find("Bomb");
        BIndWeaponControl();
    }
    void Update()
    {
        SwitchWeapon();
        DropWeapon();
        ShootAndSpecial();
        Relaod();
    }

}

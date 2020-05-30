using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureGame;
using PureGame.Codes;
using PureGame.Tools;

public class Weapon : MonoBehaviour
{
    public Camera playerCamera;
    public BaseWeapon bw = new BaseWeapon();
    public Animator anim;
    /* 攻击检测 */
    void ShootDetect()
    {
        Ray cameraRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(cameraRay, out hitInfo))
         {
                if (hitInfo.collider.transform.root.tag == "Player") 
                {
                    DamageData damageData = new DamageData();
                    damageData.Weapon = bw;
                    damageData.DamageMakerName = PlayerDictionary.Instance.localPlayer.name;
                    damageData.DamagedPlayerName = hitInfo.collider.transform.root.name;
                    if (bw.WeaponClass == WeaponType.Rifle) { damageData.Damage = Random.Range(20, 25); }
                    if (bw.WeaponClass == WeaponType.Pistol) { damageData.Damage = Random.Range(5, 10); }
                    if (bw.WeaponClass == WeaponType.Knife) 
                    {
                        if (Vector3.Distance(transform.position, hitInfo.collider.transform.position) < 1f) { damageData.Damage = Random.Range(45, 50); }
                        else { damageData.Damage = 0; }
                    }
                    RequestSender.Instance.SendDamageRequest(damageData);
                }
        }
    }
    /* 动画控制 */
    public void PlayDraw() { anim.Play("Draw"); }
    public void Shoot(WeaponType weaponType, bool specialStatus = false)
    {
        if (weaponType == WeaponType.Rifle)
        {
            if (bw.CurBulletQuantity == 0)
            {
                AudioSource.PlayClipAtPoint(Audios.Instance.rifleDryFire, transform.position); 
                return;
            }
            anim.Play("Shoot" + Random.Range(1, 4).ToString());
        }
        if (weaponType == WeaponType.Pistol)
        {
            if (bw.CurBulletQuantity == 0)
            {
                AudioSource.PlayClipAtPoint(Audios.Instance.pistolDryFire, transform.position); 
                return;
            }
            if (bw.CurBulletQuantity > 1) { anim.Play("Shoot" + Random.Range(1, 4)); }
            if (bw.CurBulletQuantity == 1) { anim.Play("Shoot_Last"); }
        }
        if (weaponType == WeaponType.Knife)
        {
            if (!specialStatus) { anim.Play("Shoot_LeftMouse"); }
            else { anim.Play("Shoot_RightMouse_Miss"); }
        }
        if (weaponType == WeaponType.Grenade)
        {
            if (!specialStatus) { anim.SetBool("isRelease", false); anim.Play("Pullpin"); }
            else { anim.SetBool("isRelease", true); }
        }
        if (weaponType == WeaponType.Bomb)
        {
            anim.Play("Planting");
        }
    }
    public void Reload() {
        if (bw.WeaponClass == WeaponType.Knife) { return; }
        if (bw.BackBulletQuantity == 0)
        {
            PlayIdle();
            return;
        }
        else if (bw.CurBulletQuantity == bw.MaxBulletQuantity)
        {
            PlayIdle();
            return;
        }
        anim.Play("Reload"); 
    }
    public void PlayIdle() { anim.Play("Idle"); }
    /* 回调函数 */
    void OnDrawStart() { transform.root.SendMessage("FalseShootReady"); }
    void OnDrawEnd() {
        if (bw.CurBulletQuantity == 0 && bw.BackBulletQuantity != 0) { Reload(); return; }
        transform.root.SendMessage("TrueShootReady"); 
    }
    void OnShootStart()
    {
        bw.CurBulletQuantity--;
        if(bw.WeaponClass != WeaponType.Knife)
            PanelManager.Instance.playerInfoPanel.GetComponent<PlayerInfoPanel>().SetBullet(bw.CurBulletQuantity, bw.BackBulletQuantity);
        transform.root.SendMessage("FalseShootReady");
    }
    void OnShootEnd()
    {
        if (bw.CurBulletQuantity != 0)
        {
            transform.root.SendMessage("TrueShootReady");
        }
        else
        {
            if (bw.BackBulletQuantity != 0) { Reload(); }
        }
    }
    void OnLastShoot()
    {
        bw.CurBulletQuantity--;
        PanelManager.Instance.playerInfoPanel.GetComponent<PlayerInfoPanel>().SetBullet(bw.CurBulletQuantity, bw.BackBulletQuantity);
        transform.root.SendMessage("FalseShootReady");
    }
    //换子弹
    void OnReloadStart() { transform.root.SendMessage("FalseShootReady"); }
    void OnReloadEnd()
    {
        int need = bw.MaxBulletQuantity - bw.CurBulletQuantity;
        if (bw.BackBulletQuantity - need >= 0)
        {
            bw.CurBulletQuantity += need;
            bw.BackBulletQuantity -= need;
        }
        else if (bw.BackBulletQuantity - need < 0)
        {
            bw.CurBulletQuantity += bw.BackBulletQuantity;
            bw.BackBulletQuantity = 0;
        }
        PanelManager.Instance.playerInfoPanel.GetComponent<PlayerInfoPanel>().SetBullet(bw.CurBulletQuantity, bw.BackBulletQuantity);
        transform.root.SendMessage("TrueShootReady");
    }
    //装炸弹
    void OnPlantingEnd() {        
        anim.Play("Planted");
        transform.root.SendMessage("FalseShootReady");
    }
    void OnBombPlanted() {
        Instantiate(Prefabs.Instance.bomb, transform.position + transform.up * 0.5f + transform.forward * 0.5f, Quaternion.identity);
        PanelManager.Instance.playerInfoPanel.OnWeaponLose(bw);
        transform.root.SendMessage("OnBombPlanted");
    }
    //投掷武器扔出
    void OnThrowing()
    {
        Instantiate(Prefabs.Instance.grenade, transform.Find("smdimport").position, Quaternion.identity);
        PanelManager.Instance.playerInfoPanel.OnWeaponLose(bw);
    }
    void OnThrowEnd() {transform.root.SendMessage("OnGrenadeThrew"); }
    /* 设置属性 绑定*/
    public void SetBaseWeapon(BaseWeapon baseWeapon)
    {
        bw = new BaseWeapon();
        bw.WeaponName = baseWeapon.WeaponName;
        bw.WeaponClass = baseWeapon.WeaponClass;
        bw.Price = baseWeapon.Price;
        bw.MaxBulletQuantity = baseWeapon.MaxBulletQuantity;
        bw.IsHaveSpecial = baseWeapon.IsHaveSpecial;
        bw.CurBulletQuantity = baseWeapon.CurBulletQuantity;
        bw.BackBulletQuantity = baseWeapon.BackBulletQuantity;
    }

    void Awake() {
        anim = GetComponent<Animator>();
        string t = (name.Remove(name.IndexOf('('))).Trim();
        bw = PureDictTool.GetValue<string, BaseWeapon>(WeaponDictionary.Instance.weaponDict, t);
    }
    void Start() {
        playerCamera = transform.root.Find("Camera").GetComponent<Camera>();
    }

    void OnEnable() {
        //if (bw.WeaponClass == WeaponType.Bomb || bw.WeaponClass == WeaponType.Knife)
            PanelManager.Instance.playerInfoPanel.GetComponent<PlayerInfoPanel>().SetBullet(bw.CurBulletQuantity, bw.BackBulletQuantity);
    }

    void OnDisable() {
        
    }
}

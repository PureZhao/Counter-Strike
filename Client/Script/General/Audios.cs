using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    private static Audios instance;

    /* 音频片段 */
    /* 通用 */
    public AudioClip rifleDryFire;
    public AudioClip pistolDryFire;
    public AudioClip blueWin;
    public AudioClip redWin;
    /* AK47 */
    public AudioClip ak47Draw;
    public AudioClip ak47ReloadStart;
    public AudioClip ak47ReloadEnd;
    public AudioClip ak47Shoot;
    /* M4A1 */
    public AudioClip m4a1DrawStart;
    public AudioClip m4a1ReloadStart;
    public AudioClip m4a1ReloadMedium;
    public AudioClip m4a1ReloadEnd;     //Also DrawEnd
    public AudioClip m4a1Shoot;
    /* AWP */
    public AudioClip awpReloadStart;
    public AudioClip awpReloadEnd;
    public AudioClip awpShoot;
    public AudioClip awpZoom;
    public AudioClip awpDragLag;
    /* Glock18 */
    public AudioClip glock18Shoot;
    /* USP */
    public AudioClip uspDrawStart;
    public AudioClip uspReloadStart;
    public AudioClip uspReloadMedium;
    public AudioClip uspReloadEnd;
    public AudioClip uspShoot;
    /* Knife */
    public AudioClip knifeDraw;
    public AudioClip knifeHit1;
    public AudioClip knifeHit2;
    public AudioClip knifeHitAir;
    public AudioClip knifeHitWall;
    public AudioClip knifeCriticalHit;
    /* Grenade */
    public AudioClip grenadeBounce;
    public AudioClip grenadeExplode;
    /* Bomb */
    public AudioClip bombBeep1;
    public AudioClip bombBeep2;
    public AudioClip bombBeep3;
    public AudioClip bombBeep4;
    public AudioClip bombBeep5;
    public AudioClip bombClick;
    public AudioClip bombPlanted;
    public AudioClip bombDisplantStart;
    public AudioClip bombDisplantEnd;
    public AudioClip bombExplode;
    /* 绑定 */
    void Awake() {
    instance = this;
    /* 通用 */
    rifleDryFire = Resources.Load("Audio/Weapon/RifleDryFire") as AudioClip;
    pistolDryFire = Resources.Load("Audio/Weapon/PistolDryFire") as AudioClip;
    blueWin = Resources.Load("Audio/Playing/BlueWin") as AudioClip;
    redWin = Resources.Load("Audio/Playing/RedWin") as AudioClip;
    /* AK47 */
    ak47Draw = Resources.Load("Audio/Weapon/AK47/Draw") as AudioClip;
    ak47ReloadStart = Resources.Load("Audio/Weapon/AK47/ReloadStart") as AudioClip;
    ak47ReloadEnd = Resources.Load("Audio/Weapon/AK47/ReloadEnd") as AudioClip;
    ak47Shoot = Resources.Load("Audio/Weapon/AK47/Shoot") as AudioClip;
    /* M4A1 */
    m4a1DrawStart = Resources.Load("Audio/Weapon/M4A1/DrawStart") as AudioClip;
    m4a1ReloadStart = Resources.Load("Audio/Weapon/M4A1/ReloadStart") as AudioClip;
    m4a1ReloadMedium = Resources.Load("Audio/Weapon/M4A1/ReloadMedium") as AudioClip;
    m4a1ReloadEnd = Resources.Load("Audio/Weapon/M4A1/ReloadEnd") as AudioClip;     //Also DrawEnd
    m4a1Shoot = Resources.Load("Audio/Weapon/M4A1/Shoot") as AudioClip;
    /* AWP */
    awpReloadStart = Resources.Load("Audio/Weapon/AWP/ReloadStart") as AudioClip;
    awpReloadEnd = Resources.Load("Audio/Weapon/AWP/ReloadEnd") as AudioClip;
    awpShoot = Resources.Load("Audio/Weapon/AWP/Shoot") as AudioClip;
    awpZoom = Resources.Load("Audio/Weapon/AWP/Zoom") as AudioClip;
    awpDragLag = Resources.Load("Audio/Weapon/AWP/DragLag") as AudioClip;
    /* Glock18 */
    glock18Shoot = Resources.Load("Audio/Weapon/Glock18/Shoot") as AudioClip;
    /* USP */
    uspDrawStart = Resources.Load("Audio/Weapon/USP/DrawStart") as AudioClip;
    uspReloadStart = Resources.Load("Audio/Weapon/USP/ReloadStart") as AudioClip;
    uspReloadMedium = Resources.Load("Audio/Weapon/USP/ReloadMedium") as AudioClip;
    uspReloadEnd = Resources.Load("Audio/Weapon/USP/ReloadEnd") as AudioClip;
    uspShoot = Resources.Load("Audio/Weapon/USP/Shoot") as AudioClip;
    /* Knife */
    knifeDraw = Resources.Load("Audio/Weapon/Knife/Draw") as AudioClip;
    knifeHit1 = Resources.Load("Audio/Weapon/Knife/Hit1") as AudioClip;
    knifeHit2 = Resources.Load("Audio/Weapon/Knife/Hit2") as AudioClip;
    knifeHitAir = Resources.Load("Audio/Weapon/Knife/HitAir") as AudioClip;
    knifeHitWall = Resources.Load("Audio/Weapon/Knife/HitWall") as AudioClip;
    knifeCriticalHit = Resources.Load("Audio/Weapon/Knife/CriticalHit") as AudioClip;
    /* Grenade */
    grenadeBounce = Resources.Load("Audio/Weapon/Grenade/Bounce") as AudioClip;
    grenadeExplode = Resources.Load("Audio/Weapon/Grenade/Explode") as AudioClip;
    /* Bomb */
    bombBeep1 = Resources.Load("Audio/Weapon/Bomb/Beep1") as AudioClip;
    bombBeep2 = Resources.Load("Audio/Weapon/Bomb/Beep2") as AudioClip;
    bombBeep3 = Resources.Load("Audio/Weapon/Bomb/Beep3") as AudioClip;
    bombBeep4 = Resources.Load("Audio/Weapon/Bomb/Beep4") as AudioClip;
    bombBeep5 = Resources.Load("Audio/Weapon/Bomb/Beep5") as AudioClip;
    bombClick = Resources.Load("Audio/Weapon/Bomb/Click") as AudioClip;
    bombPlanted = Resources.Load("Audio/Weapon/Bomb/Planted") as AudioClip;
    bombDisplantStart = Resources.Load("Audio/Weapon/Bomb/DisplantStart") as AudioClip;
    bombDisplantEnd = Resources.Load("Audio/Weapon/Bomb/DisplantEnd") as AudioClip;
    bombExplode = Resources.Load("Audio/Weapon/Bomb/Explode") as AudioClip;
    }


    public static Audios Instance
    {
        get { return Audios.instance; }
    }
}

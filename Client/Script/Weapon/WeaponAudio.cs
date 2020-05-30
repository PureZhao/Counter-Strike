using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    /* 回调函数 */
    /* AK47 */
    void PlayAK47Draw()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.ak47Draw, transform.position);
    }
    void PlayAK47ReloadStart()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.ak47ReloadStart, transform.position);
    }
    void PlayAK47ReloadEnd()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.ak47ReloadEnd, transform.position);
    }
    void PlayAK47Shoot()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.ak47Shoot, transform.position);
    }
    /* M4A1 */
    void PlayM4A1DrawStart()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.m4a1DrawStart, transform.position);
    }
    void PlayM4A1DrawEnd()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.m4a1ReloadEnd, transform.position);
    }
    void PlayM4A1ReloadStart()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.m4a1ReloadStart, transform.position);
    }
    void PlayM4A1ReloadMedium()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.m4a1ReloadMedium, transform.position);
    }
    void PlayM4A1ReloadEnd()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.m4a1ReloadEnd, transform.position);
    }
    void PlayM4A1Shoot()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.m4a1Shoot, transform.position);
    }
    /* AWP */
    void PlayAWPReloadStart()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.awpReloadStart, transform.position);
    }
    void PlayAWPReloadEnd()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.awpReloadEnd, transform.position);
    }
    void PlayAWPShoot()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.awpShoot, transform.position);
    }
    void PlayAWPZoom()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.awpZoom, transform.position);
    }
    void PlayAWPDragLag()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.awpDragLag, transform.position);
    }
    /* Glock18 */
    void PlayGlock18Shoot()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.glock18Shoot, transform.position);
    }
    /* USP */
    void PlayUSPDrawStart()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.uspDrawStart, transform.position);
    }
    void PlayUSPReloadStart()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.uspReloadStart, transform.position);
    }
    void PlayUSPReloadMedium()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.uspReloadMedium, transform.position);
    }
    void PlayUSPReloadEnd()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.uspReloadEnd, transform.position);
    }
    void PlayUSPShoot()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.uspShoot, transform.position);
    }
    /* Knife */
    void PlayKnifeDraw()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.knifeDraw, transform.position);
    }
    void PlayKnifeHitOne()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.knifeHit1, transform.position);
    }
    void PlayKnifeHitTwo()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.knifeHit2, transform.position);
    }
    void PlayKnifeHitAir()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.knifeHitAir, transform.position);
    }
    void PlayKnifeHitWall()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.knifeHitWall, transform.position);
    }
    void PlayKnifeCriticalHit()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.knifeCriticalHit, transform.position);
    }
    /* Grenade */
    void PlayGrenadeBounce()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.grenadeBounce, transform.position);
    }
    void PlayGrenadeExplode()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.grenadeExplode, transform.position);
    }
    /* Bomb */
    void PlayBombClick()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.bombClick, transform.position);
    }
    void PlayBombPlanted()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.bombPlanted, transform.position);
    }
    void PlayBombDisplantedStart()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.bombDisplantStart, transform.position);
    }
    void PlayBombDisplantedEnd()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.bombDisplantEnd, transform.position);
    }
    void PlayBombBeepOne()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.bombBeep1, transform.position);
    }
    void PlayBombBeepTwo()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.bombBeep2, transform.position);
    }
    void PlayBombBeepThree()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.bombBeep3, transform.position);
    }
    void PlayBombBeepFour()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.bombBeep4, transform.position);
    }
    void PlayBombBeepFive()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.bombBeep5, transform.position);
    }
    void PlayBombExplode()
    {
        AudioSource.PlayClipAtPoint(Audios.Instance.bombExplode, transform.position);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCountDown : MonoBehaviour
{
    public float time = 45f;

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

    IEnumerator CountDown() {
        while (time > 30f) {
            PlayBombBeepOne();
            yield return new WaitForSeconds(1.501f);
        }
        while (time > 18f)
        {
            PlayBombBeepTwo();
            yield return new WaitForSeconds(1.501f);
        }
        while (time > 9f)
        {
            PlayBombBeepThree();
            yield return new WaitForSeconds(1.501f);
        }
        while (time > 3f)
        {
            PlayBombBeepFour();
            yield return new WaitForSeconds(1.501f);
        }
        while (time > 0f)
        {
            PlayBombBeepFive();
            yield return new WaitForSeconds(1.501f);
        }
        PlayBombExplode();
        //发送游戏结束消息给服务器
    }

    void Awake() {
        StartCoroutine(CountDown());
    }

    void FixedUpdate() {
        time -= Time.fixedDeltaTime;
    }

}

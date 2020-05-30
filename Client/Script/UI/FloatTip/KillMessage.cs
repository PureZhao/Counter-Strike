using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KillMessage : MonoBehaviour
{
    public Text killerText;
    public Text killederText;
    public Image weaponImage;

    public void SetKillMessage(string killer, string weaponName, string killeder) {
        killerText.text = killer;
        weaponImage.sprite = Resources.Load("Image/Catoon/" + weaponName, typeof(Sprite)) as Sprite;
        killederText.text = killeder;
    }

    IEnumerator AutoDestroy() {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void Awake()
    {
        killerText = transform.Find("KillerText").GetComponent<Text>();
        weaponImage = transform.Find("KillWeapon").GetComponent<Image>();
        killederText = transform.Find("KillederText").GetComponent<Text>();
        StartCoroutine(AutoDestroy());
    }

}

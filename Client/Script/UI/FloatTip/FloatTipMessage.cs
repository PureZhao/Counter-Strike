using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FloatTipMessage : MonoBehaviour
{
    public void SetText(string val) {
        GetComponent<Text>().text = val;
    }

    void Start() {
        StartCoroutine(Animation());
    }

    IEnumerator Animation() {
        GetComponent<RectTransform>().DOMoveY(150f, 1f).Play();
        float a = 0f;
        for (int i = 0; i < 10; i++) {
            a += 0.1f;
            GetComponent<Text>().color = new Color(1f, 1f, 1f, a);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 10; i++)
        {
            a -= 0.1f;
            GetComponent<Text>().color = new Color(1f, 1f, 1f, a);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }

}

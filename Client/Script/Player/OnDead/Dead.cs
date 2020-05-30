using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    void Awake() {
        Animator anim = GetComponent<Animator>();
        string clipName = "Dead0" + Random.Range(1, 6);
        anim.Play(clipName);


        Destroy(gameObject, 3f);
    }
}

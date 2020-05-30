using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayer : MonoBehaviour
{
    public Animator anim;
    public Transform weaponPoint;
    void Awake()
    {
        anim = GetComponent<Animator>();
        weaponPoint = transform.Find("Bip01/Bip01 Spine/Bip01 Spine1/Bip01 Spine2Bip01 Spine/Bip01 Spine3/Bip01 Neck/Bip01 L Clavicle/Bip01 L UpperArm/Bip01 L Forearm/Bip01 L Hand");
    }

    public void Dead() {
        GetComponent<Collider>().enabled = false;
        anim.Play("Death");
    }
}

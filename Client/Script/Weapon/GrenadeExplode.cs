using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplode : MonoBehaviour
{
    
    void Awake()
    {
        GetComponent<Rigidbody>().AddForce(transform.right * 400f);
    }

    IEnumerator Explode() {
        yield return new WaitForSeconds(2.5f);
        //爆炸效果，周围玩家，传送服务器
        //Collider[] s = Physics.OverlapSphere(transform.position,10f);
    }

    void OnDestroy() {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDictionary : MonoBehaviour
{
    private static PlayerDictionary _instance;

    public Dictionary<string, GameObject> playerDict = new Dictionary<string, GameObject>();
    public GameObject localPlayer;

    /// <summary>
    /// 本地玩家函数
    /// </summary>
    public void LocalPlayerActivable(bool val) {
        localPlayer.SetActive(val);
    }
    public void LocalPlayerRespawn() {
        localPlayer.GetComponent<PlayerStatus>().Respawn();
    }
    public void LocalPlayerMovable(bool val) {
        localPlayer.GetComponent<PlayerMove>().enabled = val;
    }
    public void LocalPlayerAddMoney(int val) {
        localPlayer.GetComponent<PlayerStatus>().AddMoney(val);
    }
    public void LocalPlayerBulletRecover() {
        localPlayer.GetComponent<PlayerWeapon>().BulletRecovery();
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            if (_instance != this) {
                Destroy(gameObject);
            }
        }
    }
    
    public void AddPlayer(string userName, GameObject g) {
        playerDict.Add(userName, g);
    }
    public void RemovePlayer(string userName)
    {
        GameObject g;
        playerDict.TryGetValue(userName, out g);
        playerDict.Remove(userName);
        Destroy(g);
    }



    public static PlayerDictionary Instance
    {
        get { return PlayerDictionary._instance; }
    }
}

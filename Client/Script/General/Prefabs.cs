using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    private static Prefabs _instance;

    public GameObject localPlayerPrefab;
    public GameObject otherPlayerPrefab;
    public GameObject killMessagePrefab;
    public GameObject bomb;
    public GameObject grenade;
    public GameObject deadModel;
    void Awake()
    {
        _instance = this;

        localPlayerPrefab = Resources.Load("Prefab/Player/Player") as GameObject;
        otherPlayerPrefab = Resources.Load("Prefab/Player/OtherPlayer") as GameObject;
        killMessagePrefab = Resources.Load("Prefab/UI/KillMessageTemplate") as GameObject;
        bomb = Resources.Load("Prefab/w_Weapon/Bomb") as GameObject;
        grenade = Resources.Load("Prefab/w_Weapon/Grenade") as GameObject;
        deadModel = Resources.Load("Prefab/Player/DeadModel") as GameObject;
    }

    public static Prefabs Instance
    {
        get { return Prefabs._instance; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] int monsterNum;
    public Transform spawnPos;
    public GameObject spawnMonster;
    public DetectActor detectActor;
    private void Start()
    {
        spawnPos = this.transform;
        spawnMonster = PoolManager.instance.Get(monsterNum,spawnPos);
        detectActor = new DetectActor();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IActor player = other.GetComponent<IActor>();
            detectActor.AddActor(player);
            detectActor.ClosetActorUpdate();
            Monster monster = spawnMonster.GetComponent<Monster>();
            monster.spawnerDetectActor = detectActor.closetActor;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IActor player = other.GetComponent<IActor>();
            detectActor.RemoveActor(player);
            detectActor.ClosetActorUpdate();
            Monster monster = spawnMonster.GetComponent<Monster>();
            monster.spawnerDetectActor = detectActor.closetActor;
        }
    }
}

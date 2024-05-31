using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
public class MonsterSpawnerManager : MonoBehaviour
{
    List<Vector3> monsterSpawnPos;
    [SerializeField] GameObject monsterSpawn;
    [SerializeField] List<GameObject> monsterSpawnList;

    private void Start()
    {
        monsterSpawnPos = new List<Vector3>
        {
            new Vector3(38, -94f, 151f),
            new Vector3(28, -94f, 151f)
        };
        MonsterSpawn();
    }

    void MonsterSpawn()
    {
        for(int i =0; i < monsterSpawnPos.Count; i++)
        {
            GameObject monsterSpawnObj = Instantiate(monsterSpawn, monsterSpawnPos[i], Quaternion.identity,transform);
            monsterSpawnList.Add(monsterSpawnObj);
        }
    }
}

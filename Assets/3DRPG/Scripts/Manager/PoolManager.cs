using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class PoolManager : MonoBehaviour 
{
    public static PoolManager instance;
    [SerializeField] GameObject[] prefabs;
    List<GameObject>[] pools;
    private void Awake()
    {
        instance = this;
        pools = new List<GameObject>[prefabs.Length];
        for(int i =0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }
    public GameObject Get(int index, Transform transform)
    {
        GameObject select = null;

        foreach(GameObject obj in pools[index])
        {
            if(!obj.activeSelf)
            {
                select = obj; 
                select.SetActive(true);
                break;
            }
        }
        if(!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        return select;
    }
}

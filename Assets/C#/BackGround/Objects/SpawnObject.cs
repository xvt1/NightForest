using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    
    [SerializeField] private GameObject[] spawnObject;
    [SerializeField] private float mincooldown, maxcooldown,time;

    [SerializeField] private Transform[] spawnpoints;

    [SerializeField] private float timeoffset;

    [SerializeField] private Menu menu;

    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
    }

    void Update()
    {
        if (!menu.GetStart()) return;
        int random = 0;
        if(time <= 0)
        {
            random = UnityEngine.Random.Range(0,spawnObject.Length);
            time = UnityEngine.Random.Range(mincooldown,maxcooldown);
            Instantiate(spawnObject[random], spawnpoints[random].position, Quaternion.identity);
            Inst(random);
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    void  Inst(int f)
    {
        if (timeoffset <= 0)
        {
            for (int i = 0; i < spawnObject.Length; i++)
            {
                if (i != f)
                {
                    Instantiate(spawnObject[i], spawnpoints[i].position, Quaternion.identity);
                }
            }
        }
    }
}

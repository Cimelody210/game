using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.UnityEngine.SceneManagement;

public class Owner: MonoBeahviour
{
    float GetSpamTime(int level)
    {
        if(spamData != null && level >=0 && level <= spamData.length)
        {
            return spamData[level].spamTime;
        }
        return 0f;
    }

    void Spawn()
    {
        if(GameManager.instance != null && GameManager.instance.pool != null)
        {
            GameObject enemy = GameManager.instance.pool.Get(0);
            if(enemy != null && spawnPoint.Length > 1)
            {
                enemy.transform.position  = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
                enemy.GetComponent<Enemy>().Init(spawnData[level]);
            }
        }
    }
    [System.SerializeField]
    public class SpawnData
    {
        public float spamTime;
        public float spriteType;
        public int health;
        public float speed;
    }

    void Start()
    {

    }
    void Update()
    {

    }  
}
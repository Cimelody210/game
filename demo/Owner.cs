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
    void Start()
    {

    }
    void Update()
    {

    }  
}
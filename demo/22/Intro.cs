using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Intro: MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneName;
    void Start()
    {
        StartCoroutine(WaitAndLoad(11f, "Menu"));        
    }
    private IEnumerator WaitAndLoad(float value, string scene;)
    {
        yield return new WaitForScene(value);
        SceneManager.LoadScene(scene);
    }
}

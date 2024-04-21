using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.UnityEngine.SceneManagement;

public class AudioManager: MonoBeahviour
{
  public static GameManager instance;
  
  [Header("#Game Control")]
  public bool isLive;
  public float gameTime;
  public float maxGameTime = 2 * 10f;
  
  [Header("#Player info")]
  public float health;
  public float maxHealth = 100;
  public int level;
  public int kill;
  public int exp;
  public int[] nextExp  = {3,5,10,100,150, 210, 200, 450, 600};
  
  [Header("#Game object")]
  public GameObject enemyCleaner;
  public Player player;
  public Towner towner;
  public LevelUp levelup;
  public PoolManager pool;
  
  void Awake()
  {
    instance = this;
  }

  public void GameStart()
  {
    uiLevelUp.Hide();
    health = maxHealth;
    uiLevelUp.Select(0);
    Resume();
    AudioManager.instance.PlayBgm(true);
    AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
  }
  void Start()
  {
    
  }
  
  void Update()
  {
    
  }
  
  public void ()
  {
    if(!PauseMenuScript.isPaused)
    {
      if(active)
    }
  }
}
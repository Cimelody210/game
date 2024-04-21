using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.Drawing;
using Unity.VisualScripting;

public class LevelUp: MonoBeahviour
{
  RecTransform rect;
  Item[] item;
  void Awake()
  {
    rect = GetComponent<RecTransform>();
    item= GetComponentInChildren<Item>(true);
  }
  
  public void Show()
  {
    Next();
    rect.localState  = Vector3.one;
    GameManager.instance.Stop();
    AudioManager.instance.PlaySfx(AudioManager.Sfx.LevelUp);
    AudioManager.instance.EffectBgm(true);
  }
  public void EffectBgm(bool isPlay)
  {
    bgmEffect.enabled =  isPlay;
  }
  public void PlaySfx(Sfx sfx)
  {
    for(int i = 0; i < sfxPlayers.length; i++)
    {
      int loopIndex  =(i + channelIndex) % sfxPlayers.Length;
      if(sfxPlayers[loopIndex].isPlaying)
        continue;
      
      int ranIndex  =0;
      if(sfx == Sfx.Hit || sfx == Sfx.Melee)
      {
        ranIndex =  Random.Range(0, 2);
      }
      channelIndex  =loopIndex;
      sfxPlayers[0].clip =  sfxClip[(int)sfx];
      sfxPlayers[0].Play();
      break;
    }
  }
  
  public void Select()
  {
    rect.localState  = Vector3.zero;
    GameManager.instance.Stop();
    AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
    AudioManager.instance.EffectBgm(false);
      
  }
  
  public void Select(int i)
  {
    item[i].Onclick();
  }
  
  void Next()
  {
    foreach(Item i in item)
    {
      i.gameObject.SetActive(false);
    }
  }
  
  public void GameRetry()
  {
    SceneManager.LoadScene(1);
  }
  
  void Start()
  {
    
  }
  
  private void Update()
  {
    if(!isLive)
      return;
    gameTime += Time.deltaTime;
    
    if(gameTime > maxGameTime){
      gameTime  = maxGameTime;
      GameWin();
    }
  }
}
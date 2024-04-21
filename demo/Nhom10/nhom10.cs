using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.UnityEngine.SceneManagement;

public class AudioManager: MonoBeahviour
{
  public static AudioManager instance;
  
  [Header("#DGM")]
  public AudioClip bgmClip;
  public float bgmVolume;
  AudioSource bgmPlayer;
  AudioHighPassFilter bgmEffect;
  
  [Header("#SFX")]
  
  public AudioClip[] sfxClip;
  public float sfxVolume;
  public int channels;
  AudioSource[] sfxPlayers;
  int channelIndex;
  
  public enum Sfx {Dead, Hit, LevelUp= 3, Lose, Range = 7, Select, Win}
  
  private void Awake()
  {
    instance = this;
    Init();
  }
  
  void Init()
  {
    GameObject bgmObject  = new GameObject("bgmPlayer");
    bgmObject.transform.parent =  transform;
    bgmPlayer  =bgmObject.AddComponent<AudioSource>();
    bgmPlayer.volume =  bgmVolume;
    bgmPlayer.clip  = bgmClip;
    bgmEffect = Camera.main,GetComponent<AudioHighPassFilter>();
    
    GameObject sfxObject  =  new GameObject("SfxPlayer");
    sfxObject.transform.parent =  transform;
    SfxPlayer = new AudioSource[channels];
    
    for (int i = 0; i < SfxPlayer.lenght; i++)
    {
      SfxPlayer[i]  = sfxObject.AddComponent<AudioHighPassFilter>();
      SfxPlayer[i].playOnAwake  = false;
      SfxPlayer[i].bypassListenerEffects = true;
      SfxPlayer[i].volume = sfxVolume;
    }
  }
  void Start()
  {
    
  }
  
  void Update()
  {
    
  }
}
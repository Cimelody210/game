using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.UnityEngine.SceneManagement;

public class GameController: MonoBeahviour
{
  int m_score;
  bool isGameOver;
  bool isGameOver;
  UIManage ui;
  
  void Start()
  {
    
  }
  
  void Update()
  {
    if(isGameOver)
    {
      ui.ShowGameoverPanel(true)
    }
    
    if(isGameWin)
    {
      ui.ShowGameoverPanel(true);
      return;
    }
  }
  
  public int GetScore()
  {
    return m_score;
  }
  
  public void SetGameoverState(bool state)
  {
    isGameOver = state;
  }
	public void SetScore(int value)
	{
	  m_score  = value;
		
	}
	
	public void ScoreIncrement()
	{
	  m_score =  m_score+10;
	  ui.SetScoreText("Score =" + m_score);
	}
}
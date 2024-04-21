using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.UnityEngine.SceneManagement;

public class Tile: MonoBeahviour
{
    private void OnMouseOver()
    {
        if(active)
        {
            if(Input.GetMouseButtonDown(0)){
                ClickedTile();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                flagged  = !flagged;
                if(flagged)
                {
                    spriteRenderer.sprite  = flaggedTile;
                }
                else
                {
                    spriteRenderer.sprite  = ClickedTile[mineCount];
                    if(mineCount == 0)
                    {
                        gameManager.ClickNeighbours(this);
                    }
                    gameManager.CheckGameOver();
                }
            }
        }
    }
    int m_score;
    bool isGameOver;
    bool isGameOver;
    UIManage ui;
    void Start()
    {
        
    }
  
}
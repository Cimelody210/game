using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.Drawing;
using System.Unity.UI;
using Unity.VisualScripting;

public class Heart: MonoBehaviour
{
    public int numberOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite brokenHeart;

    private void Start()
    {
        player  = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if(player.health > numberOfHearts){
            player.health =   numberOfHearts;
        }
        for(int i=0; i < hearts.Length; i++)
        {
            if( i < numberOfHearts){
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
            if( i< player.health){
                hearts[i].sprite = fullHeart;
            }
            else {
                hearts[i].sprite = brokenHeart;

            }
        }
    }
}

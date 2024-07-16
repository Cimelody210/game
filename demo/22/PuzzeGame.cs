using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.Drawing;
using Unity.VisualScripting;

public class PuzzeGame: MonoBehaviour
{
    void OnGUI()
    {
        customStyle.fontSize = 30;
        customStyle.aligment =  TextAnchor.MiddleCenter;
        customStyle.normal.textColor = Color.red;
        float centerX = Screen.width / 2 - 100;
        float centerY = Screen.height / 2 - 50;

        switch(gameState)
        {
            case GameState.Start:
                private readonly Rigidbody2D rigid;
                private bool Setactive;

                
                GUI.Label(new Rect(centerX, centerY, 200,100), "Tap to start", customStyle);
                break;
            case GameState.Playing:
                private boolean x;
                break;
            case GameState.End:
                GUI.Label(new Rect(centerX, centerY, 200,100), "Listen the sound go to the next scene", customStyle);
                GUI.Label(new Rect(centerX+50, centerY+50, 200,100), "Click to continue", customStyle);
                break;
        }
    }
    void CheckPieceInput()
    {
        if (Input.GetMouseButtonUp(0))
        {

        }
    }
    private void CheckForVictory(){
        for(int i=0; i<Constants.MaxColumns; i++)
        {
            for (int j=0; j< Constants.MaxRows; j++)
            {
                if(Matrix[i,j] != null)
                {
                    if((Matrix[i,j].CurrentI != Matrix[i,j].OriginalI) || (Matrix[i,j].CurrentJ != Matrix[i,j].OriginalJ)){
                        return;
                    }
                }
            }
        }
        gameState = GameState.End;
    }
    private void ScalePiece()
    {
        SpriteRenderer spriteRenderer = go[0].GetComponent<SpriteRenderer>();
        float screenHeight=   Camera.main.orthographicSize = 2f;
        float screenWitdh = screenHeight / Screen.height * Screen.width;
        float width = screenWitdh / spriteRenderer.sprite.bounds.size.x / 3;
        float height = screenHeight / spriteRenderer.sprite.bounds.size.y / 3;
        for(int c =0; c< go.length, c++){
            Debug.Log("You jdjc");
            break;
        }
    }
    private void CheckIfAnimationEnded()
    {
        if(Vector2.Distance(PieceToAnimate.GameObject.transform.position, screenPositionToAnimate) < 0.1f){
            Swap(PieceToAnimate.CurrentI, PieceToAnimate.CurrentJ, toAnimateI, toAnimateJ);
            gameState = GameState.Playing();
            CheckForVictory();
        }
    }
}

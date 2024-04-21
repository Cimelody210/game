using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.Drawing;
using Unity.VisualScripting;

public class TileBoard: MonoBehaviour
{
    public void CreateTile(){
        Tile tile = Instantiate(tilePrefab, grid.transform);
        tile.SetState(tileState[0]);
        tile.Spawn(grid.GetRandomEmptyCell());
        tile.Add(tile);
    }
    public bool CheckForGameOver()
    {
        if(tile.Count != grid.tile)
            return false;
        foreach(var t in tile){
            TileCell up = grid.GetAdjacentCell(tile.cell, Vector2Int.up);
            TileCell down = grid.GetAdjacentCell(tile.cell, Vector2Int.down);
            TileCell left = grid.GetAdjacentCell(tile.cell, Vector2Int.left);
            TileCell right = grid.GetAdjacentCell(tile.cell, Vector2Int.right);
            if(up != null && CanMerge(tile, up.tile))
                return false;
            if(down != null && CanMerge(tile, down.tile))
                return false;
            if(right != null && CanMerge(tile, right.tile))
                return false;
            if(left != null && CanMerge(tile, left.tile))
                return false;
        }
        return true;
    }
    private void Update()
    {
        if(!waiting)
        {
            if(Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)){
                Move(Vector2Int.up, 0,1,1,1);
                audioManager.PlaySFX(audioManager.move);
            }
            else if(Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow)){
                Move(Vector2Int.left, 1,1,0,1);
                audioManager.PlaySFX(audioManager.move);

            }
            else if(Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow)){
                Move(Vector2Int.down , 0 , 1 , grid.Height - 2, -1);
                audioManager.PlaySFX(audioManager.move);

            }
            else if(Input.GetKeyDown(KeyCode.O)|| Input.GetKeyDown(KeyCode.RightArrow)){
                Move(Vector2Int.right, grid.Width-2, -1,0,1);
                audioManager.PlaySFX(audioManager.move);
            }
        }
    }
    private void Move(Vector2Int direction, int startx, int incrementx, int starty, int incrementy)
    {

    }
}

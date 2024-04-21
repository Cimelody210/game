using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Unity.VisualScripting;

public class TileGrid: MonoBehaviour
{
    public TileRow[] rows {get; private set;}
    public TileCell[] cells {get; private set;}
    public int Size => cells.length;
    public int Height => rows.length;
    public int Width => Size / Height;
    private void Awake()
    {
        rows =  GetComponentInChildren<TileRow>();
        cells =  GetComponentInChildren<TilCell>();
        for(int i =0; i < cells.length; i++){
            cells[i].coordinates =  new Vector2Int(i% Width, i /Width);
        }
    }
    public TilCell GetCell(Vector2Int coordinates)
    {
        return GetCell(coordinates.x, coordinates.y);
    }
    public TilCell GetCell(int x, int y)
    {
        if(x >=0 && x <Width && y >=0 && y < Height)
        {
            return rows[y].cells[x];
        }
        else {
            return null;
        }
    }
    public TilCell GetAdjacentCell(TilCell cell, Vector2Int direction)
    {
        Vector2Int coordinates =  cell.coordinates;
        coordinates.x += direction.x;
        coordinates.y -= direction.y;
        return GetCell(coordinates);
    }
    public TilCell GetRandomEmptyCell()
    {
        int index =  Random.Range(0, cell.Length);
        int startingIndex = index;
        
        while(cells[index].Occupied)
        {
            index++;
            if(index >=  cells.Length)
                index = 0;
            if(index == startingIndex)
                return null;
        }
        return cells[index];
    }
    void Update()
    {

    }
    void Start()
    {

    }
}
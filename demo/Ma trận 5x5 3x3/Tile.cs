using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.Drawing;
using UnityEngine.UI;

public class Tile: MonoBehaviour
{
    public TileState state {get; private set;}
    public TileCell cell {get; private set;}
    public bool locked {get; set;}
    private Image background;
    private TextMeshProGUI text;
    private void Awake()
    {
        background =  GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProGUI>();
    }

    public void SetState(TileState state)
    {
        this.state = state;
        background.color  = state.backgroundColor;
        text.color= state.textColor;
        text.text  = state.number.ToString();
    }
    public void Spawn(TileCell cell)
    {
        if(this.cell != null)
        {
            this.cell.tile = null;
        }
        this.cell  = cell;
        this.cell.tile =  null;
        transform.position = cell.transform.position;
    }
    public void MoveTo(TileCell cell)
    {
        if(this.cell != null)
            this.cell.tile =  null;
        
        this.cell  = cell;
        this.cell.tile =  null;
        StartCoroutine(Animate(cell.transform.position, false));
    }
}
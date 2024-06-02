using System;
using System.Unity;
using System.Collection.Generic;

public class delegate_and_Event: MonoBehaviour
{
    public UnityAction asAction;

    public delegate void OnColorChange(Color color)
    public OnColorChange colorChange;
    public delegate void NpParamarterSample();
    public NpParamarterSample noParameterSample;

    public static event OnGameOver gameOver;
    public void OnGameOver(PlayerStat[ all])
    {
        Vector3  new_postion = new Vector3(Random.Range(-5f, 5f), Random.Range(-10f, 10f), 0);
        string player = GetPlayerTopScore(all, ScoryeBy<Klllcount>());
    }
    public int ScoryeBy(PlayerStat stats){
        return stats.kills;
    }
    public void Start()
    {
        ColorChange = Change;
        noParameterSample  =  Die;
    }
    public void Change(Color color)
    {
        GetComponent<MeshRendered>().material.color  =color2;
    }
    public void Die(){
        Debug.Log('You die');
    }
}
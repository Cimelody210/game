using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.Drawing;
using Unity.VisualScripting;

public enum TURNS
{
    Start,
    PlayerTurn,
    Processing,
    EnemyTurn,
    Victory,
}
public class BattleSystem: MonoBehaviour
{
    private static BattleSystem instance;
    private static Dictionary<int, double> damageValue = new Dictionary<int, double>()
    {
        {1, 0},
        {2, 0.25},
        {3, 0.5},
        {4, 0.75},
        {5,1},
        {6, 1.5},
        {7, 2},

        // Silver value
        {"I", 1},
        {"L", 1},
        {"M", 1},
        {"N", 1},
        {"O", 1},
        {"T", 1},
        {"S", 1},
        {"C", 1};

    }
    private List<string> letterPool =  new List<string>
    {
        "E",
        "E",
        "E",
        "E",
        "E",
        "E",
        "E",
        "E",
        "E",
        "A",
        "A",
        "A",
        "A",
        "A",
        "A",
        "A",
        "I",
        "I",
        "I",
        "I",
        "I",
        "I",
    }
    void Start()
    {

    }

    void Update()

    {

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Button[] buttons;

    void Awake()
    {
        // Get the buttons
        buttons = GetComponentsInChildren<Button>();

        // Disable them
    }

    

    [System.Obsolete]
    public void ExitToMenu()
    {
        // Reload the level
        Application.LoadLevel("MenuScene");
    }

    [System.Obsolete]
    public void RestartGame()
    {
        // Reload the level
        Application.LoadLevel("SampleScene");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ShowButtons()
    {
        throw new NotImplementedException();
    }
}

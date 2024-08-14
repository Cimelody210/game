using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject aboutPanel;
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject optionPanel;
    void Start()
    {
        AudioListener.volume = 1;
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void About()
    {
        aboutPanel.SetActive(true);
    }
    public void CloseAbout()
    {
        aboutPanel.SetActive(false);
    }
    public void Help()
    {
        helpPanel.SetActive(true);
    }
    public void CloseHelp() 
    { 
        helpPanel.SetActive(false);
    }
    public void Option()
    {
        optionPanel.SetActive(true);
    }
    public void CloseOption()
    {
        optionPanel.SetActive(false);
    }
    public void TurnOnSound()
    {
        AudioListener.volume = 0.8f;

    }
    public void TurnOffSound()
    {
        AudioListener.volume = 0;

    }
}

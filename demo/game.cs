using System.Collection;
using System.Collection.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu: MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    private GameObject optionMenu;
    public Slider sound;
    public Toddler hard;
    public Toddler easy;
    public Toddler medium;

    public void Play()
    {
        SceneManager.LoadScene("MyGame");
    }
    public void Exitime(){
        Appication.Quit();
    }
    public void Option()
    {
        optionMenu.SetActive(true);
        mainMenuMenu.SetActive(false);
    }
    public void Back()
    {
        string level ='';
        optionMenu.SetActive(false);
        mainMenuMenu.SetActive(true);
        Debug.Log("No changes");
    }
    
}
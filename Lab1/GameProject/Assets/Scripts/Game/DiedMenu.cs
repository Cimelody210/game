using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedMenu : MonoBehaviour
{
    [SerializeField] GameObject diedMenu;
    public void Freeze()
    {
        Invoke("DelayedFreeze", 2f);
    }

    private void DelayedFreeze()
    {
        Time.timeScale = 0f;
        diedMenu.SetActive(true);

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        diedMenu.SetActive(false);
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
}

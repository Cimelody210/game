using log4net.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int score = 0;
    public bool isGameOver = false;

    [SerializeField]
    private GameObject shipModel;
    [SerializeField]
    private GameObject startGameButton;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text titleText;
    [SerializeField]
    private Spawner spawner;

    private static Game instance;

    private int highScore;

    private void Start()
    {
        instance = this;
        titleText.enabled = true;
        gameOverText.enabled = false;
        scoreText.enabled = false;
        startGameButton.SetActive(true);
    }

    public static void GameOver()
    {
        instance.titleText.enabled = true;
        instance.startGameButton.SetActive(true);
        instance.isGameOver = true;
        instance.spawner.StopSpawning();
        instance.shipModel.GetComponent<Ship>().Explode();
        instance.gameOverText.enabled = true;
    }

    public void NewGame()
    {
        isGameOver = false;
        titleText.enabled = false;
        startGameButton.SetActive(false);
        shipModel.transform.position = new Vector3(0, -3.22f, 0);
        shipModel.transform.eulerAngles = new Vector3(90, 180, 0);
        score = 0;
        instance.highScore = LoadHighScore();
        scoreText.text = "SCORE: " + score + " / " + instance.highScore.ToString();
        scoreText.enabled = true;
        spawner.BeginSpawning();
        shipModel.GetComponent<Ship>().RepairShip();
        spawner.ClearAsteroids();
        gameOverText.enabled = false;
    }

    public static void AsteroidDestroyed()
    {
        instance.score++;
        if(instance.score > instance.highScore)
        {
            instance.highScore = instance.score;
        }
        instance.scoreText.text = "Score: " + instance.score + " / " + instance.highScore.ToString();
        instance.SaveHighScore(instance.score);
    }

    public Ship GetShip()
    {
        return shipModel.GetComponent<Ship>();
    }

    public Spawner GetSpawner()
    {
        return spawner.GetComponent<Spawner>();
    }

    public void SaveHighScore(int score)
    {
        instance.highScore = LoadHighScore();
        if(instance.highScore < score)
        {
            GlobalVariables.Set("HighScore", score);
        }
    }

    public int LoadHighScore()
    {
        int HighScore = GlobalVariables.Get<int>("HighScore");
        return HighScore;
    }
}

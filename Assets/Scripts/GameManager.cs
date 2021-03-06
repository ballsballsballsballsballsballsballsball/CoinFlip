using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int wins;
    public int losses;
    public int lives = 100;
    public int heads;
    public int tails;
    
    // save these
    public int globalWins;
    public int globalLosses;

    public Text winLossText;
    public Text livesText;
    public Text headsTailsText;
    public Text coinSideText;
    public Text globalStatsText;
    
    public GameObject coinFlipParent;
    public GameObject[] coinFlippers;

    public GameObject playingParent;
    public GameObject gameOverParent;
    public Text scoreText;
    public AudioSource audioSource;
    
    public GameObject coinFlipper;
    
    private void Awake()
    {
        LoadGame();
        Instance = this;
        DontDestroyOnLoad(gameObject);
        ReplaceLives();
        ReplaceWinLoss();
        ReplaceGlobalStats();
        CreateCoinFlipper();
        gameOverParent.SetActive(false);
        playingParent.SetActive(true);
    }

    void CreateCoinFlipper()
    {
        coinFlipper = Instantiate(coinFlippers[UnityEngine.Random.Range(0, coinFlippers.Length)], coinFlipParent.transform);
    }

    public void ReplaceLives()
    {
        livesText.text = $"Lives: {lives}";
    }

    public void ReplaceHeadsTails()
    {
        headsTailsText.text = $"Heads: {heads}\n Tails: {tails}";
    }

    public void ReplaceGlobalStats()
    {
        globalStatsText.text = $"Global stats:\nWins: {globalWins}\nLosses: {globalLosses}";
    }
     
    public void ReplaceWinLoss()
    {
        winLossText.text = $"Wins: {wins}\n Losses: {losses}";
    }

    public void RestartGame()
    {
        coinSideText.text = "No coin";
        heads = 0;
        tails = 0;
        ReplaceHeadsTails();
        Destroy(coinFlipper);
        CreateCoinFlipper();
    }

    public void GameOver()
    {
        playingParent.SetActive(false);
        gameOverParent.SetActive(true);
        scoreText.text = $"Your final score was:\n{wins} wins\n{losses} losses";
    }

    public void Reset()
    {
        wins = 0;
        losses = 0;
        lives = 100;
        ReplaceWinLoss();
        ReplaceLives();
        heads = 0;
        tails = 0;
        ReplaceHeadsTails();
        Destroy(coinFlipper);
        CreateCoinFlipper();
        playingParent.SetActive(true);
        gameOverParent.SetActive(false);
    }

    // save load
    public void SaveGame()
    {
        string s = "";
        
        s += globalWins.ToString() + "|";
        s += globalLosses.ToString();

        PlayerPrefs.SetString("SaveState", s);
        PlayerPrefs.Save();
    }
    
    public void LoadGame()
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            globalWins = 0;
            globalLosses = 0;
            return;
        };

        string s = PlayerPrefs.GetString("SaveState");
        string[] data = s.Split('|');

        globalWins = int.Parse(data[0]);
        globalLosses = int.Parse(data[1]);
    }
}

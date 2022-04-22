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


    public Text winLossText;
    public Text livesText;
    public Text headsTailsText;
    public Text coinSideText;
    
    public GameObject coinFlipParent;
    public GameObject[] coinFlippers;
    
    public GameObject coinFlipper;
    
    private void Awake()
    {
        SceneManager.sceneLoaded += LoadGame;
        Instance = this;
        DontDestroyOnLoad(gameObject);
        ReplaceLives();
        ReplaceWinLoss();
        CreateCoinFlipper();
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
    
    // save load
    public void SaveGame()
    {
        string s = "";
        
        s += wins.ToString() + "|";
        s += losses.ToString() + "|";
        s += lives.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }
    
    public void LoadGame(Scene scene, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState")) return;

        string s = PlayerPrefs.GetString("SaveState");
        string[] data = s.Split('|');

        wins = int.Parse(data[0]);
        losses = int.Parse(data[1]);
        lives = int.Parse(data[2]);
    }
}

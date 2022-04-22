﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinFlipper : MonoBehaviour
{
    public float headsOdds = 1;
    public bool cheater;
    
    public void FlipCoin()
    {
        if (!cheater)
        {
            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 0)
            {
                FlipTails();
            }
            else
            {
               FlipHeads();
            }
        }
        else
        {
            float randomNumber = Random.Range(0, headsOdds);
            var rounded = Math.Round(randomNumber, 2);
            if (rounded <= 0.5)
            {
                FlipTails();
            }
            else
            {
                FlipHeads();
            }
        }
        GameManager.Instance.lives--;
        CheckLife();
        
    }

    public void Fair()
    {
        if (!cheater)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    public void Cheater()
    {
        if (cheater)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }
    
    private void FlipHeads()
    {
        GameManager.Instance.heads++;
        GameManager.Instance.coinSideText.text = "Heads";
        GameManager.Instance.ReplaceHeadsTails();
    }

    private void FlipTails()
    {
        GameManager.Instance.tails++;
        GameManager.Instance.coinSideText.text = "Tails";
        GameManager.Instance.ReplaceHeadsTails();
    }

    private void Win()
    {
        GameManager.Instance.wins++;
        GameManager.Instance.ReplaceWinLoss();
        GameManager.Instance.RestartGame();
        GameManager.Instance.lives += 5;
        CheckLife();
    }

    private void Lose()
    {
        GameManager.Instance.losses++;
        GameManager.Instance.ReplaceWinLoss();
        GameManager.Instance.RestartGame();
        GameManager.Instance.lives -= 10;
        CheckLife();
    }

    private void CheckLife()
    {
        GameManager.Instance.ReplaceLives();
        if (GameManager.Instance.lives <= 0)
        {
            // TODO: implement game over
            Debug.Log("Game Over");
        }
    }
}

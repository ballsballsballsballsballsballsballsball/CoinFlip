using System;
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
}

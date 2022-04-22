using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public void FlipCoin()
    {
        CoinFlipper child = GameManager.Instance.coinFlipParent.transform.GetChild(0).GetComponent<CoinFlipper>();
        child.FlipCoin();
    }

    public void MarkFair()
    {
        CoinFlipper child = GameManager.Instance.coinFlipParent.transform.GetChild(0).GetComponent<CoinFlipper>();
        child.Fair();
    }

    public void MarkCheater()
    {
        CoinFlipper child = GameManager.Instance.coinFlipParent.transform.GetChild(0).GetComponent<CoinFlipper>();
        child.Cheater();
    }
}

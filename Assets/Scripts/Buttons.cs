using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private CoinFlipper _child;
    private void Start()
    {
        _child = GameManager.Instance.coinFlipParent.transform.GetChild(0).GetComponent<CoinFlipper>();
    }

    public void FlipCoin()
    {
        _child.FlipCoin();
    }
}

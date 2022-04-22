using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private bool _musicDisabled = true;
    public void FlipCoin()
    {
        CoinFlipper child = GameManager.Instance.coinFlipParent.transform.GetChild(0).GetComponent<CoinFlipper>();
        child.FlipCoin();
    }

    public void MarkFair()
    {
        CoinFlipper child = GameManager.Instance.coinFlipParent.transform.GetChild(0).GetComponent<CoinFlipper>();
        child.OnSubmit();
    }

    public void MarkCheater()
    {
        CoinFlipper child = GameManager.Instance.coinFlipParent.transform.GetChild(0).GetComponent<CoinFlipper>();
        child.OnSubmit(true);
    }

    public void Reset()
    {
        GameManager.Instance.Reset();
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        GameManager.Instance.LoadGame();
        GameManager.Instance.ReplaceGlobalStats();
    }

    public void ToggleMusic()
    {
        _musicDisabled = !_musicDisabled;
        GameManager.Instance.audioSource.mute = _musicDisabled;
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}

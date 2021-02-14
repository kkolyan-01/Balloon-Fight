using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadPanel : MonoBehaviour
{
    [SerializeField] private Text _allCoins;
    [SerializeField] private Text _height;
    [SerializeField] private Text _bestHeight;
    
    private void OnEnable()
    {
        UpdateAllCoins();
        UpdateHeight();
        UpdateBestHeight();
    }

    private void UpdateAllCoins()
    {
        int coins = GameManager.s.coins;
        int allCoins = SaveManager.GetAllCoins();
        _allCoins.text = $"+{coins} ({allCoins})";
    }

    private void UpdateHeight()
    {
        float height = GameManager.s.height;
        _height.text = height + "m";
    }
    
    private void UpdateBestHeight()
    {
        float bestHeight = SaveManager.GetBestHeight();
        _bestHeight.text = bestHeight + "m";
    }
}

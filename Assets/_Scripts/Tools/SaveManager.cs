using System;
using UnityEngine;

public static class SaveManager
{
    public static void Save()
    {
        SaveBestHeight();
    }

    public static void AddGlobalCoins(int coins)
    {
        int AllCoins = PlayerPrefs.GetInt("Coins");
        AllCoins += coins;
        PlayerPrefs.SetInt("Coins", AllCoins);
    }
    
    public static void RemoveGlobalCoins(int coins)
    {
        int AllCoins = PlayerPrefs.GetInt("Coins");
        AllCoins -= coins;
        PlayerPrefs.SetInt("Coins", AllCoins);
    }
    

    private static void SaveBestHeight()
    {
        float meter = GameManager.s.height;

        if (PlayerPrefs.HasKey("BestHeight"))
        {
            float bestMeter = PlayerPrefs.GetFloat("BestHeight");
            if (meter > bestMeter)
            {
                PlayerPrefs.SetFloat("BestHeight", meter);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("BestHeight", meter);
        }
    }

    public static int GetAllCoins()
    {
        return PlayerPrefs.GetInt("Coins");
    }   

    public static float GetBestHeight()
    {
        return PlayerPrefs.GetFloat("BestHeight");
    }
}
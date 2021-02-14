using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager s;

    private int _coins;
    private float _height;

    public int coins => _coins;
    public float height
    {
        get { return _height; }
        set
        {
            if (value > _height)
            {
                _height = (float) Math.Round(value, 1);
                UIManager.s.UpdateMeter();
            }
        }
    }

    private void Awake()
    {
        if(s == null)
            s = this;
        else
            Debug.LogError("Попытка создать второй GameManager!");
    }

    public void Lose()
    {
        SaveManager.Save();
        UIManager.s.EnableDeadPanel();
    }
    
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void AddCoins(int coins)
    {
        _coins += coins;
        UIManager.s.UpdateCoins();
        SaveManager.AddGlobalCoins(coins);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager s;

    [SerializeField] private Text _coinsText;
    [SerializeField] private Text _meterText;
    [SerializeField] private GameObject _deadPanel;

    private void Awake()
    {
        s = this;
    }

    private void Start()
    {
        UpdateAll();
        _deadPanel.SetActive(false);
    }

    public void UpdateAll()
    {
        UpdateCoins();
        UpdateMeter();
    }

    public void UpdateCoins()
    {
        int coins = GameManager.s.coins;
        _coinsText.text = coins.ToString();
    }

    public void UpdateMeter()
    {
        float meter = GameManager.s.height;
        if(meter % 1 == 0)
            _meterText.text = meter + ",0m";
        else
        _meterText.text = meter + "m";
    }

    public void EnableDeadPanel()
    {
        _deadPanel.SetActive(true);
    }
    
}

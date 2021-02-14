using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class BalloonManager : MonoBehaviour
{
    [SerializeField] private UnityEvent allBallonsBoom;
    
    private List<Balloon> _balloons;
    public int count => _balloons.Count;

    private void Awake()
    {
        _balloons = new List<Balloon>();
    }

    private void Start()
    {
        if (count <= 0)
            allBallonsBoom.Invoke();
    }

    public void RemoveBalloon(Balloon balloon)
    {
        _balloons.Remove(balloon);
        if (count <= 0)
            allBallonsBoom.Invoke();
    }
    
    public void addBalloon(Balloon balloon)
    {
        _balloons.Add(balloon);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Balloon : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private UnityEvent _boomEvent;
    [SerializeField] private BalloonManager _balloonManager;

    private void Awake()
    {
        _balloonManager?.addBalloon(this);
    }

    public void Die()
    {
        GameObject boom = Instantiate(_explosionPrefab);
        boom.transform.position = transform.position;
        _boomEvent.Invoke();
        _balloonManager?.RemoveBalloon(this);
        Destroy(gameObject);
    }
}

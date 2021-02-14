using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WrapBounds))]
[RequireComponent(typeof(Thorns))]
public class Fireball : MonoBehaviour
{
    [SerializeField] private float _speed;

    private WrapBounds _wrapBounds;

    private void Start()
    {
        _wrapBounds = GetComponent<WrapBounds>();
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        if (!_wrapBounds.isOnScreen)
        {
            Destroy(gameObject);
        }
    }
}

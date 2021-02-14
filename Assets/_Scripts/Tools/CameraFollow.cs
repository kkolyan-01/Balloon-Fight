using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _balloon;
    [SerializeField] private float _delta;
    private void Update()
    {
        if(_balloon == null) return;
        Vector3 pos = transform.position;
        if (pos.y <= _balloon.position.y)
        {
            pos.y = Mathf.Lerp(pos.y, _balloon.position.y, _delta * Time.deltaTime);
        }

        transform.position = pos;

    }
}

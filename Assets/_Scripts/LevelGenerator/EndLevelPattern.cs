using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WrapBounds))]
public class EndLevelPattern : MonoBehaviour
{
    private WrapBounds _bounds;

    private void Start()
    {
        _bounds = GetComponent<WrapBounds>();
    }

    private void Update()
    {
        if (_bounds.outDown)
        {
            GameObject levelPatern = transform.parent.gameObject;
            LevelGenerator.s.DestroyPattern(levelPatern);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector3 _mousePosition
    {
        get
        {
            Vector3 mousePositionOnScreen = Input.mousePosition;
            Vector3 mousePositionOnScene = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
            mousePositionOnScene.z -= Camera.main.transform.position.z;
            return mousePositionOnScene;
        }
    }

    private void Update()
    {
        RotateToMouse();
    }

    private void RotateToMouse()
    {
        Vector3 angles = transform.eulerAngles;
        if (_mousePosition.x > 0)
        {
            angles.y = 0;
        }
        else
        {
            angles.y = 180;
        }

        transform.eulerAngles = angles;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapBounds : MonoBehaviour
{
    [SerializeField] private Vector2 _size;

    [Header("Wrap")] 
    [SerializeField] private bool _wrapX;
    [SerializeField] private bool _wrapY;
    
    [Header("Dynamically")] 
    [SerializeField] private bool _isOnScreen;
    [SerializeField] private bool _outLeft, _outRight, _outUp, _outDown;

    public bool outLeft => _outLeft;
    public bool outRight => _outRight;
    public bool outUp => _outUp;
    public bool outDown => _outDown;
    public bool isOnScreen => _isOnScreen;
    
    private float _boundsX;
    private float _boundsY;

    private void Start()
    {
        _isOnScreen = true;
        _boundsY = Camera.main.orthographicSize - _size.y;
        _boundsX = Camera.main.orthographicSize * Camera.main.aspect - _size.x;
    }


    
    private void Update()
    {
        CheckBounds();
        if (!_isOnScreen)
        {
            Wrap();
        }
    }

    private void CheckBounds()
    {
        Vector3 posCamera = Camera.main.transform.position;
        Vector3 pos = transform.position - posCamera;
        
        _outLeft = _outRight = _outUp = _outDown = false;
        _isOnScreen = true;
        
        if (pos.x > _boundsX)
        {
            _outRight = true;
        }

        if (pos.x < -_boundsX)
        {
            _outLeft = true;
        }
        
        if (pos.y > _boundsY)
        {
            _outUp = true;
        }

        if (pos.y < -_boundsY)
        {
            _outDown = true;
        }
        
        _isOnScreen = !(_outLeft || _outRight || _outUp || _outDown);
    }
    
    private void Wrap()
    {
        Vector3 pos = transform.position;
        Vector3 posCamera = Camera.main.transform.position;
        
        if (_outRight && _wrapX)
        {
            pos.x = -_boundsX + posCamera.x;
            _outRight = false;
        }
        if (_outLeft && _wrapX)
        {
            pos.x = _boundsX + posCamera.x;
            _outLeft = false;
        }
        if (_outUp && _wrapY)
        {
            pos.y = -_boundsY + posCamera.y;
            _outUp = false;
        }
        if (_outDown && _wrapY)
        {
            pos.y = _boundsY + posCamera.y;
            _outDown = false;
        }
        
        transform.position = pos;
        _isOnScreen = !(_outLeft || _outRight || _outUp || _outDown);
    }
}

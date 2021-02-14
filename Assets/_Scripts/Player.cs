using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(WrapBounds))]
public class Player : MonoBehaviour
{
   [SerializeField] private float _forceTapY;
   [SerializeField] private float _forceTapX;

   private Rigidbody2D _rigidbody;
   private WrapBounds _wrapBounds;
   private bool _isDead;
   private bool _isFall;
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
   private void Start()
   {
      InitializeComponents();
      _isDead = false;
   }

   private void InitializeComponents()
   {
      _rigidbody = GetComponent<Rigidbody2D>();
      _wrapBounds = GetComponent<WrapBounds>();
   }

   private void Update()
   {
      if (Input.GetMouseButton(0))
      {
         if(!_isFall)
            AddForce();
      }

      KeepUp();
      GameManager.s.height = transform.position.y;
      if (_wrapBounds.outDown && !_isDead)
      {
         Die();
      }
   }

   private void AddForce()
   {
      float forceTapX = _forceTapX * Time.deltaTime;
      float forceTapY = _forceTapY * Time.deltaTime;
      Vector2 tempVel = _rigidbody.velocity;

      if (_mousePosition.x < 0)
      {
         forceTapX *= -1;
      }

      _rigidbody.velocity = tempVel;
      _rigidbody.AddForce(new Vector2(forceTapX, forceTapY));
   }
   
   private void KeepUp()
   {
      if (_wrapBounds.outUp)
      {
         Vector2 tempVel = _rigidbody.velocity;
         tempVel.y = 0;
         _rigidbody.velocity = tempVel;
      }
   }

   public void Fall()
   {
      _rigidbody.gravityScale = 2;
      _isFall = true;
   }

   public void Die()
   {
      _isDead = true;
      GameManager.s.Lose();
      Destroy(gameObject);
   }
   
   

}

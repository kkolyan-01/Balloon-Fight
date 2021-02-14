using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] private GameObject _fireballPrefab;
    [SerializeField] private float _attackPerSecond;

    private void Start()
    {
        StartCoroutine(Attack());
    }

    private void Fire()
    {
        GameObject fireball = Instantiate(_fireballPrefab);
        fireball.transform.position = transform.position;
        fireball.transform.eulerAngles = transform.eulerAngles;
        transform.SetParent(transform);
    }

    private IEnumerator Attack()
    {
        Fire();
        yield return new WaitForSeconds(1 / _attackPerSecond);
        StartCoroutine(Attack());
    }
}

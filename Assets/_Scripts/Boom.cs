using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boom : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    void Start()
    {
        StartCoroutine(DestroyBoom());
    }

    private IEnumerator DestroyBoom()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}

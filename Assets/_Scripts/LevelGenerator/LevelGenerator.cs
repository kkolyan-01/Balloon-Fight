using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator s;
    
    [SerializeField] private GameObject[] _levelPatternsPrefabs;
    [SerializeField] private Transform _startLevel;
    [SerializeField] private int _patternsOnScene;

    private List<GameObject> _createdPatterns;
    private Vector3 _createPatternPosition;
    private GameObject _parentLevel;

    private void Awake()
    {
        if(s == null)
            s = this;
        else
            Debug.LogError("Попытка создать второй LevelGenerator!");
    }

    private void Start()
    {
        _createPatternPosition = _startLevel.position;
        InitializeComponetnts();
        CreateStartPatterns();
    }

    private void InitializeComponetnts()
    {
        _parentLevel = new GameObject("LevelPatterns");
        _createdPatterns = new List<GameObject>();
    }

    private void CreateStartPatterns()
    {
        for (int i = 0; i < _patternsOnScene; i++)
        {
            CreatePattern();
        }
    }
    

    private void CreatePattern()
    {
        int randomIndex = Random.Range(0, _levelPatternsPrefabs.Length);
        GameObject pattern = Instantiate(_levelPatternsPrefabs[randomIndex]);
        pattern.transform.SetParent(_parentLevel.transform);
        pattern.transform.position = _createPatternPosition;
        Vector3 endPotternPosition = pattern.transform.Find("End").position;
        _createPatternPosition = endPotternPosition;
        _createdPatterns.Add(pattern);
    }

    public void DestroyPattern(GameObject pattern)
    {
        _createdPatterns.Remove(pattern);
        Destroy(pattern);
        CreatePattern();
    }
}

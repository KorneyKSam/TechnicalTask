using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] GameObject _roadPrefab;
    [SerializeField] float _maxSpeed = 10f;
    [SerializeField] int _maxRoadCount = 5;
    private float _speed = 0f;
    private List<GameObject> _roads = new List<GameObject>();
    private const float lengthOfRoad = 29f;
    
    void Start()
    {
        ResetLevel();
        StartLevel();
    }

    private void StartLevel()
    {
        _speed = _maxSpeed;
    }

    void Update()
    {
        if (_speed == 0) return;
        foreach (GameObject road in _roads)
        {
            road.transform.position -= new Vector3(0, 0, _speed * Time.deltaTime);
        }

        if (_roads[0].transform.position.z < -lengthOfRoad)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
            CreateNextRoad();
        }
    }

    public void ResetLevel()
    {
        _speed = 0;
        while (_roads.Count > 0)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
        }
        for (int i = 0; i < _maxRoadCount; i++)
        {
            CreateNextRoad();
        }
    }

    private void CreateNextRoad()
    {
        Vector3 position = Vector3.zero;
        if (_roads.Count > 0)
        {
            position = _roads[_roads.Count - 1].transform.position + new Vector3(0, 0, lengthOfRoad);
        }
        GameObject road = Instantiate(_roadPrefab, Vector3.zero, Quaternion.identity);
        road.transform.SetParent(transform);
        _roads.Add(road);
    }
}

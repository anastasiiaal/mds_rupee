using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeManager : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Rupee rupeePrefab;
    [SerializeField] private Transform spawner;
    [SerializeField, Range(0.1f, 5f)] private float spawnDelay = 1f;
    
    public event Action<Rupee> OnRupeeCollected;

    private readonly List<Rupee> _rupees = new();
    private Coroutine _spawnRoutine;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        _spawnRoutine = StartCoroutine(SpawnRoutine());
    }
    
    public void StopSpawning()
    {
        if(_spawnRoutine != null)
        {
            StopCoroutine(_spawnRoutine);
            _spawnRoutine = null;
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Spawn()
    {
        var rupee = Instantiate(rupeePrefab, spawner.position, Quaternion.identity, container);
        AddRupee(rupee);
    }

    private void AddRupee(Rupee rupee)
    {
        _rupees.Add(rupee);
        rupee.OnCollected += RupeeCollectedHandler;
        // Debug.Log(_rupees.Count);
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        _rupees.Remove(rupee);
        rupee.OnCollected -= RupeeCollectedHandler;
        OnRupeeCollected?.Invoke(rupee);
        // Debug.Log(_rupees.Count);
    }
}

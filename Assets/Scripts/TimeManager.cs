using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField, Range(10f, 600f)] private float duration = 120f;

    public event Action OnTimeUp;

    private float _remaining;
    private bool _running;
    
    public float Remaining => _remaining;
    
    void Start()
    {
        _remaining = duration;
        _running = true;
    }
    
    void Update()
    {
        if (!_running) return;
        
        _remaining -= Time.deltaTime;

        if (_remaining <= 0)
        {
            _remaining = 0f;
            _running = false;
            OnTimeUp?.Invoke();
        }
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private TimeManager _timeManager;
    private RupeeManager _rupeeManager;

    private void Awake()
    {
        _scoreManager = GetComponent<ScoreManager>();
        _timeManager = GetComponent<TimeManager>();
        _rupeeManager = GetComponent<RupeeManager>();
    }

    private void OnEnable()
    {
        _timeManager.OnTimeUp += HandleTimeUp;
        _rupeeManager.OnRupeeCollected += HandleRupeeCollected;
    }
    
    private void OnDisable()
    {
        _timeManager.OnTimeUp -= HandleTimeUp;
        _rupeeManager.OnRupeeCollected -= HandleRupeeCollected;
    }

    private void HandleRupeeCollected(Rupee rupee)
    {
        _scoreManager.IncrementScore();
    }

    private void HandleTimeUp()
    {
        _rupeeManager.StopSpawning();
    }
}

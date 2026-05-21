using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action OnGameStarted;
    public event Action OnGameStopped;
    
    private ScoreManager _scoreManager;
    private TimeManager _timeManager;
    private RupeeManager _rupeeManager;
    [SerializeField]
    private PlayerController player;

    private void Awake()
    {
        _scoreManager = GetComponent<ScoreManager>();
        _timeManager = GetComponent<TimeManager>();
        _rupeeManager = GetComponent<RupeeManager>();
    }

    public void StartGame()
    {
        _scoreManager.ResetScore();
        _timeManager.ResetTimer();
        _rupeeManager.ResetRupees();
        
        _timeManager.StartTimer();
        _rupeeManager.StartSpawning();
        player.SetCanMove(true);

        OnGameStarted?.Invoke();
    }

    public void StopGame()
    {
        // _rupeeManager.StopSpawning();
        _rupeeManager.ResetRupees();
        player.SetCanMove(false);
        OnGameStopped?.Invoke();
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
        StopGame();
    }
}

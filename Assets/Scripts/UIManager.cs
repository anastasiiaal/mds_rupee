using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(ScoreManager),  typeof(TimeManager))]
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject startButton;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    
    private ScoreManager _scoreManager;
    private TimeManager _timeManager;
    private GameManager _gameManager;

    private void Awake()
    {
        _scoreManager = GetComponent<ScoreManager>();
        _timeManager = GetComponent<TimeManager>();
        _gameManager = GetComponent<GameManager>();
    }

    private void OnEnable()
    {
        _gameManager.OnGameStarted += HandleGameStarted;
        _gameManager.OnGameStopped += HandleGameStopped;
    }
    
    private void OnDisable()
    {
        _gameManager.OnGameStarted -= HandleGameStarted;
        _gameManager.OnGameStopped -= HandleGameStopped;
    }

    private void Update()
    {
        scoreText.text = $"Score : {_scoreManager.Score}";
        timerText.text = TimeSpan.FromSeconds(_timeManager.Remaining).ToString(@"mm\:ss");
        bestScoreText.text = $"Best : {_scoreManager.BestScore}";
    }

    private void HandleGameStarted()
    {
        startButton.SetActive(false);
    }

    private void HandleGameStopped()
    {
        startButton.SetActive(true);
    }
}

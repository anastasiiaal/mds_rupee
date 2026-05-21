using TMPro;
using UnityEngine;

[RequireComponent(typeof(ScoreManager),  typeof(TimeManager))]
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    
    private ScoreManager _scoreManager;
    private TimeManager _timeManager;

    private void Awake()
    {
        _scoreManager = GetComponent<ScoreManager>();
        _timeManager = GetComponent<TimeManager>();
    }

    private void Update()
    {
        scoreText.text = $"Score : {_scoreManager.Score}";
        timerText.text = $"{_timeManager.Remaining}";
    }
}

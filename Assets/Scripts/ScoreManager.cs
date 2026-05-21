using UnityEngine;

[RequireComponent(typeof(RupeeManager))]
public class ScoreManager : MonoBehaviour
{
    private int _score;
    private int _bestScore;
    
    private const string BestScoreKey = "BestScore";
    
    public int Score => _score; // quand on appelle Score depuis autre classe, on obtient la valeur de _score
    public int BestScore => _bestScore;

    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    public void IncrementScore()
    {
        _score++;
        TrySaveBestScore();
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public void TrySaveBestScore()
    {
        if (_score > _bestScore)
        {
            _bestScore = _score;
            PlayerPrefs.SetInt(BestScoreKey, _bestScore);
            PlayerPrefs.Save();
            // Debug.Log($"Score: {_score} | Best score: {_bestScore}");
        }
    }
}

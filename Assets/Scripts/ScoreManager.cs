using UnityEngine;

[RequireComponent(typeof(RupeeManager))]
public class ScoreManager : MonoBehaviour
{
    
    private RupeeManager _rupeeManager;
    private int _score;
    
    public int Score => _score; // quand on appelle Score depuis autre classe, on obtient la valeur de _score

    private void Awake()
    {
        _rupeeManager = GetComponent<RupeeManager>();
    }

    private void OnEnable()
    {
        _rupeeManager.OnRupeeCollected += HandleRupeeCollected;
    }
    
    private void OnDisable()
    {
        _rupeeManager.OnRupeeCollected -= HandleRupeeCollected;
    }

    private void HandleRupeeCollected(Rupee rupee)
    {
        _score++;
        // Debug.Log("Score: " + _score);
    }
}

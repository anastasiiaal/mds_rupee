using UnityEngine;

[RequireComponent(typeof(RupeeManager))]
public class ScoreManager : MonoBehaviour
{
    
    private RupeeManager _rupeeManager;
    private int _score;
    
    public int Score => _score; // quand on appelle Score depuis autre classe, on obtient la valeur de _score

    public void IncrementScore()
    {
        _score++;
    }
    
    
}

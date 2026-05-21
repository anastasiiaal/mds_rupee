using UnityEngine;

[CreateAssetMenu(fileName = "RupeeData", menuName = "Rupees/RupeeData")]
public class RupeeData : ScriptableObject
{
    public Color color =  Color.limeGreen;
    public int score = 1;
    public AudioClip pickupSound;
    
    
}

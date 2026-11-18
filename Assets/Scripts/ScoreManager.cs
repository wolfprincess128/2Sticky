using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float currentscore;
    [SerializeField] private float totalScore;
    public float multiplier;
    private void Update()
    {
        UpdateTotal();
        Debug.Log("current: "+ currentscore + " max: " + totalScore);
    }
    public void AddScore(int _amount)
    {
        currentscore += _amount * multiplier;
        
    }
    public void SubtractScore(int _amount)
    {
        currentscore -= _amount;
    }
    private void UpdateTotal()
    {
        if (currentscore > totalScore) totalScore = currentscore;
    }
}

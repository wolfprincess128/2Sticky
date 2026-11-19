using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float currentscore;
    [SerializeField] private float totalScore;
    public float multiplier;
    private void Update()
    {
        UpdateTotal();
    }
    public void AddScore(int _amount)
    {
        currentscore += _amount * multiplier;
        Debug.Log("current: "+ currentscore + " max: " + totalScore);
    }
    public void SubtractScore(int _amount)
    {
        currentscore -= _amount;
        Debug.Log("current: "+ currentscore + " max: " + totalScore);
    }
    private void UpdateTotal()
    {
        if (currentscore > totalScore) totalScore = currentscore;
    }
}

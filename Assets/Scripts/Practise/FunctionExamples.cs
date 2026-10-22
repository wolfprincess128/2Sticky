using UnityEngine;

public class FunctionExamples : MonoBehaviour
{
    public int totalCoins= 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TakeDamage(66);
        int coinage = CollectCoins(128);
        int healthRemaining = CalculateHealth(128, 300);
        Debug.Log("how many coins" + coinage);
        Debug.Log("health Remaining? Health:" + healthRemaining);
    }

    void TakeDamage(int damage)
    {
    Debug.Log("You got whooped for " + damage + " Damage!");
    }

    private int CollectCoins(int Coins)
    {
        int newCoins = totalCoins + Coins;
        return newCoins;
    }

    private int CalculateHealth(int health, int damage)
    {
        int result = health - damage;
        return result;
    }
}

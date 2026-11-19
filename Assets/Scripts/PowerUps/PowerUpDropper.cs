using UnityEngine;

public class PowerUpDropper : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUps = new GameObject[3];
    public void RollPowerup()
    {
        if (Random.Range(0, 11) >= 9)
        {
        int random = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[random], transform.position, Quaternion.identity);
        }
    }
}
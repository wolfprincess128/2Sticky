using UnityEngine;

public class PowerUpComponent : MonoBehaviour
{
    [SerializeField] private int referenceIndex;
    PowerUpManager powerupManager;
    private void Start()
    {
        powerupManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            powerupManager.powerupCount[referenceIndex]++;
            Destroy(gameObject);
        }
    }
}

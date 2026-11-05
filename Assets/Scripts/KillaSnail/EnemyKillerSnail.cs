using UnityEngine;
using UnityEngine.AI;

public class EnemyKillerSnail : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    private PlayerHealth playerHealth;
    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        playerTransform = GameObject.Find("player").GetComponent<Transform>();
        playerHealth = GameObject.Find("player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DistanceToTarget() 
    {
     
    }
}

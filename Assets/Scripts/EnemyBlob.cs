using UnityEngine;
using UnityEngine.AI;

public class EnemyBlob : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackDistance;
    [SerializeField] private GameObject Explosion;

    private NavMeshAgent agent;

    public static bool isSlowEffect;

    private float speedMultiplier;

    [SerializeField] private Vector3 moveDirection;

    private Transform playerTransform;
    private float distanceToPlayer;
    PlayerHealth Health;

    void HandleSpeed()
    {
        if (isSlowEffect)
        {
            agent.speed = 0.75f;
        }
        else
        {
            agent.speed = 2.5f;
        }
    }
    void Start()
    {
        playerTransform = GameObject.Find("player").GetComponent<Transform>();
        Health = GameObject.Find("player").GetComponent<PlayerHealth>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        HandleSpeed();
        //transform.Translate(moveDirection.normalized * speedMultiplier * Time.deltaTime);
        //distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
        agent.SetDestination(playerTransform.position);
        float distanceToPlayer = DistanceToTarget();
        if (distanceToPlayer <= attackDistance)
        {
            Health.takeDamage(damage);
            Debug.Log(Health.HP);
            Explosion.transform.parent = null;
            Explosion.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    private float DistanceToTarget() 
    {
     float distance = Vector3.Distance(transform.position, playerTransform.position);
     return distance;
    }

    private void OnCollisionEnter(Collision other)
    {
        moveDirection = Vector3.Reflect(
            moveDirection, other.GetContact(0).normal);
            
    }
}

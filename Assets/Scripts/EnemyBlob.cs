using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyBlob : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackDistance;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject poisonEffect;

    [SerializeField] private float health = 20f;

    private NavMeshAgent agent;

    public static bool isSlowEffect;

    private float speedMultiplier;

    [SerializeField] private Vector3 moveDirection;

    private Transform playerTransform;
    private float distanceToPlayer;
    PlayerHealth Health;

    void Start()
    {
        playerTransform = GameObject.Find("player").GetComponent<Transform>();
        Health = GameObject.Find("player").GetComponent<PlayerHealth>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

        void Update()
    {
        HandleSpeed();
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

    public void TakeDamage(float _damage)
    {
       health -= _damage;

       if (health <= 0f)
       {
        Destroy(this.gameObject);
       } 
    }

    public void DoPoison(float _length,float _damage)
    {
        StartCoroutine(TakePoison(_length,_damage));
    }

    private IEnumerator TakePoison(float _length,float _damage)
    {
        float timer = 0f;

        while (timer < _length)
        {
            if (this != null)
            {
            TakeDamage(_damage);
            Explosion.transform.parent = null;
            if (poisonEffect != null) poisonEffect.SetActive(true);
            yield return new WaitForSeconds(1f);
            timer++;
            if (poisonEffect != null) poisonEffect.SetActive(false);
            }
        }
    }

     public void DoKnockback(float _force, float _time)
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward * _force, ForceMode.Impulse);
        StartCoroutine(EndKnockback(rb, _time));
    }

    private IEnumerator EndKnockback(Rigidbody rb , float _time)
    {
       yield return new WaitForSeconds(_time);
       rb.linearVelocity = Vector3.zero;
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

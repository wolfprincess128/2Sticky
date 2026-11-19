using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyBlob : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackDistance;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject poisonEffect;
    [SerializeField] private Vector3 moveDirection;

    [SerializeField] private float health = 20f;

    private NavMeshAgent agent;
    public static bool isSlowEffect;
    private float speedMultiplier;
    private Transform playerTransform;
    private float distanceToPlayer;
    private PlayerHealth Health;
    private ScoreManager score;
    private PowerUpDropper powerup;
    private ShopTrigger bar;

    void Start()
    {
        playerTransform = GameObject.Find("player").GetComponent<Transform>();
        Health = GameObject.Find("player").GetComponent<PlayerHealth>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        score = GameObject.Find("player").GetComponent<ScoreManager>();
        powerup = this.gameObject.GetComponent<PowerUpDropper>();
        bar = GameObject.Find("ShopTrigger").GetComponent<ShopTrigger>();
    }

        void Update()
    {
        HandleSpeed();
        if (bar.inShop)
        {
            agent.SetDestination(transform.position);
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;

        }
        else
        {
            agent.SetDestination(playerTransform.position);
        }

        
        float distanceToPlayer = DistanceToTarget();
        if (distanceToPlayer <= attackDistance)
        {
            Health.takeDamage(damage);
            Debug.Log(Health.HP);
            Explosion.transform.parent = null;
            Explosion.SetActive(true);
            score.SubtractScore(20);
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
        score.AddScore(20);
        powerup.RollPowerup();
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

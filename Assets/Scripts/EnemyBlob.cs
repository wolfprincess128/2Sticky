using UnityEngine;

public class EnemyBlob : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackDistance;
    [SerializeField] private GameObject Explosion;

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
            speedMultiplier = 0.75f;
        }
        else
        {
            speedMultiplier = 2.5f;
        }
    }
    void Start()
    {
        playerTransform = GameObject.Find("player").GetComponent<Transform>();
        Health = GameObject.Find("player").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        HandleSpeed();
        transform.Translate(moveDirection.normalized * speedMultiplier * Time.deltaTime);
        distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
        if (distanceToPlayer <= attackDistance)
        {
            Health.takeDamage(damage);
            Debug.Log(Health.HP);
            Explosion.transform.parent = null;
            Explosion.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        moveDirection = Vector3.Reflect(
            moveDirection, other.GetContact(0).normal);
            
    }
}

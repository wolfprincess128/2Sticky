using UnityEngine;

public class EnemyBlob : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float attackDistance;

    [SerializeField] private Vector3 moveDirection;
    private Transform playerTransform;
    private float distanceToPlayer;
    playerHealth Health;

    void Start()
    {
        playerTransform = GameObject.Find("player").GetComponent<Transform>();
        Health = GameObject.Find("player").GetComponent<playerHealth>();
    }

    void Update()
    {
        transform.Translate(moveDirection.normalized *2* Time.deltaTime);
        distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
        if (distanceToPlayer <= attackDistance)
        {
            Health.HP = Health.HP - damage;
            Debug.Log(Health.HP);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        moveDirection = Vector3.Reflect(
            moveDirection, other.GetContact(0).normal);
            
    }
}

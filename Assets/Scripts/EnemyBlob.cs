using UnityEngine;

public class EnemyBlob : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection;
    void Start()
    {
    }

    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        moveDirection = Vector3.Reflect(
            moveDirection, other.GetContact(0).normal);
            
    }
}

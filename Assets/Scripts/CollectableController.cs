using UnityEditor.UI;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Transform collectableTransform;
    private Transform playerTransform;
    private float distanceToPlayer;
    void Start()
    {
        collectableTransform = GameObject.Find("Collectable").GetComponent<Transform>();
        playerTransform = GameObject.Find("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(playerTransform.position, collectableTransform.position);
    
        if(distanceToPlayer <= 1f)
        { 
            Destroy(this.gameObject);
        }
    }
}

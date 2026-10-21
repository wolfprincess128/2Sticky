using UnityEditor.UI;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    Transform collectableTransform;
    Transform playerTransform;
    float distanceToPlayer;
    Score scoreRef;
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
            scoreRef.scorePoints++;
            Debug.Log(scoreRef.scorePoints);
            GameObject.Destroy(collectableTransform.gameObject);
        }
    }
}

using UnityEditor.UI;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Transform collectableTransform;
    private Transform playerTransform;
    private float distanceToPlayer;
    Score scoreRef;
    void Start()
    {
        collectableTransform = GameObject.Find("Collectable").GetComponent<Transform>();
        playerTransform = GameObject.Find("player").GetComponent<Transform>();
        scoreRef = GameObject.Find("Collectable").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(playerTransform.position, collectableTransform.position);
    
        if(distanceToPlayer <= 1f)
        { 
            scoreRef.scorePoints++;
            Debug.Log(scoreRef.scorePoints);
            Destroy(this.gameObject);
        }
    }
}

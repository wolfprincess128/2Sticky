using UnityEngine;

public class WhileLoopExample : MonoBehaviour
{
    private int playerDamage;
    private int monsterHealth = 100;


    void Start()
    {
       while(monsterHealth > 0)
       {
        playerDamage = UnityEngine.Random.Range(1, 17);
        monsterHealth -= playerDamage;
        Debug.Log("damage dealt" + playerDamage);
       Debug.Log("monster Health = " + monsterHealth);
       } 
       Debug.Log("good job kid you killed it.");
       
    }
}

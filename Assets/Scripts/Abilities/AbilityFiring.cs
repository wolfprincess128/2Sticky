using UnityEngine;
using System.Collections;


public class AbilityFiring : MonoBehaviour
{
    [SerializeField] private Ability ability;
    void Start()
    {
        StartCoroutine(ProjectileFire());
    }

    IEnumerator ProjectileFire()
    {
        while(true)
        {
            GameObject projectile = Instantiate(ability.projectile, transform.position, transform.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * ability.projectileSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(ability.projectileRate);  
        }
        
    }
}
 

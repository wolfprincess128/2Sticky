using UnityEngine;
using System.Collections;


public class AbilityFiring : MonoBehaviour
{
    [SerializeField] private Ability ability;
    private ShopTrigger bar;
    void Start()
    {
        StartCoroutine(ProjectileFire());
        bar = GameObject.Find("ShopTrigger").GetComponent<ShopTrigger>();
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
 

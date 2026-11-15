using UnityEngine;
using System.Collections;

public abstract class Ability : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;
    private bool hasHitEnemy;
    public float projectileRate;
    [SerializeField] private float projectileDamage;
    [SerializeField] private string weaponName;
    
    
    private void OnTriggerEnter(Collider other)
    {
        bool damageApplied = ApplyDamage(other.gameObject);

        if (hasHitEnemy)
        {
            return;
        }

        if (damageApplied)
        {
            hasHitEnemy = true;
            ApplyEffect(other.gameObject);
            Destroy(gameObject);
        }
       
    }

    private void Start()
    {
        StartCoroutine(TimeOutProjectile());
    }
    IEnumerator TimeOutProjectile()
    {
        yield return new WaitForSeconds(projectileRate * 5);
        Destroy(gameObject);     
    }

    private bool ApplyDamage(GameObject target)
    {
        EnemyBlob enemy = target.GetComponent<EnemyBlob>();
        if (enemy != null)
        {
            enemy.TakeDamage(projectileDamage);
            return true;
        }
        return false;
    }

    protected virtual void ApplyEffect(GameObject target)
    {

    }
}


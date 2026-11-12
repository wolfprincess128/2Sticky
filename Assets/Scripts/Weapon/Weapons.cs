using UnityEngine;

public class Weapons : MonoBehaviour
{
    private float projectileSpeed;
    private int projectileDamage;
    private int weaponAmmo;
    
    public void Attack()
    {
        if (weaponAmmo > 0)
        {
            weaponAmmo--;
            Debug.Log("Yo you atack");
        }
        else 
        {
            Debug.Log("no amo :(");
        }
    }

    public virtual void Shoot()
    {
        Debug.Log("!!!!aaaa shoot");
    }
}

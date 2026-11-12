using UnityEngine;

public class Bow : Weapons
{
 public void Start()
    {
        Attack();
        Shoot();
    }
    public override void Shoot()
    {
        Debug.Log("!!!!bow!!!!!!!! hahahaha shoot");
    }
}

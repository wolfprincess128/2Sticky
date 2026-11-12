using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string weaponName;
    [SerializeField] protected int ammoAmount;

    protected virtual void Shoot()
    {
        Debug.Log("Shoot brah");
    }

    public virtual void MegaBeam()
    {
        Debug.Log("Bro used megabeam omfg");
    }
}

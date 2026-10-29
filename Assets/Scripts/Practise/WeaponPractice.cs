using UnityEngine;

public class WeaponPractice
{
    public string weaponName;
    public float weaponDamage;

    public WeaponPractice() {
        weaponName = "Blaster";
        weaponDamage = 1;
    }
    public WeaponPractice(string _name, float _damage) 
    {
        weaponName = _name;
        weaponDamage = _damage;
    }
}

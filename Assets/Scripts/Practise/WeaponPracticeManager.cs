using UnityEngine;

public class WeaponPracticeManager : MonoBehaviour
{
    WeaponPractice SweetDeath = new WeaponPractice("Sweet DeathRay", 3);
    WeaponPractice BlueBols = new WeaponPractice();
    void Start()
    {
        Debug.Log(SweetDeath.weaponName + ":" + SweetDeath.weaponDamage);
        Debug.Log(BlueBols.weaponName + ":" + BlueBols.weaponDamage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class PowerupManagertest : MonoBehaviour
{
    powerupTest Rum = new powerupTest("Rum and Whine", 10);
    powerupTest BathBom = new powerupTest("Bath Bomb", 5);
    void Start()
    {
        Debug.Log("You got the freaking " + Rum.powerupName + " For " + Rum.powerupDuration + " Seconds");
        Debug.Log("You got the freaking " + BathBom.powerupName + " For " + BathBom.powerupDuration + " Seconds");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

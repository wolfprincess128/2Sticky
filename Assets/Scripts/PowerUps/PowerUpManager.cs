using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUpManager : MonoBehaviour
{
    private PowerUp[] powerUps = new PowerUp[3];

    void Start()
    {
        powerUps[0] = new PowerUp("Rum and Whine", 15);
        powerUps[1] = new PowerUp("Bath Bomb", 5);
        powerUps[2] = new PowerUp("ChalkDuster", 10);
    }
    void Update()
    {
        HandleCountdowns();
        HandlePowerupSelection();
    }
    private void HandleCountdowns()
    {
        for (int i = 0; i < powerUps.Length; i++)
        {
            if (powerUps[i].isActive == true)
            {
                powerUps[i].CountDown();
            }
        }
    }

    private void HandlePowerupSelection()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            ActvatePowerup(0);
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            ActvatePowerup(1);
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            ActvatePowerup(2);
    }
    private void ActvatePowerup(int _Index)
    {
        powerUps[_Index].isActive = true;
        Debug.Log("Your Powerup is !!! Active!!!");
    }

}

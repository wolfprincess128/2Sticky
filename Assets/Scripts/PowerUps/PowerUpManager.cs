using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUpManager : MonoBehaviour
{
    private PowerUp[] powerUps = new PowerUp[3];
    public int[] powerupCount = new int[3];
    private PlayerController Player;
    private PlayerHealth playerHP;

    

    void Start()
    {
        powerUps[0] = new PowerUp("Rum and Whine", 7);
        powerUps[1] = new PowerUp("Bath Bomb", 3);
        powerUps[2] = new PowerUp("ChalkDuster", 7);
        Player = GameObject.Find("player").GetComponent<PlayerController>();
        playerHP = GameObject.Find("player").GetComponent<PlayerHealth>();
    }
    void Update()
    {
        HandleCountdowns();
        HandlePowerupSelection();
        HandlePowerUpEffects();
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

    private void HandlePowerUpEffects()
    {
        for (int i = 0; i < powerUps.Length; i++)
        {
            switch(i)
            {
                case 0:
                    Player.isSpeedEffect = powerUps[i].isActive;
                    break;
                case 1:
                    playerHP.isInvincible = powerUps[i].isActive;
                    break;
                case 2:
                    EnemyBlob.isSlowEffect = powerUps[i].isActive;
                    break;
                default:
                    Debug.Log("no power up with index " + i);
                    break;
            }
        }
    }

    private void HandlePowerupSelection()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame )
            ActvatePowerup(0); // Increases Movement Speed 2x
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            ActvatePowerup(1); // Makes you temporarily Invunerable
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            ActvatePowerup(2); // Makes Enemy Speed Lower
    }
    private void ActvatePowerup(int _Index)
    {
        if (powerUps[_Index].isActive == false && powerupCount[_Index] > 0)
                {
            powerUps[_Index].isActive = true;
            powerupCount[_Index]--;
            Debug.Log("Your Powerup is !!! Active!!!");
        }
       
    }

}

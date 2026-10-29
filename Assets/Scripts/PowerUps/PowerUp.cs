using UnityEngine;

public class PowerUp
{
    public string powerupName;
    public float powerupDuration;
    public bool isActive;
    private float originalDuration;

    public PowerUp()
    {
        powerupName = "Test Powerup";
        powerupDuration = 10;
    }

    public PowerUp(string _name, float _duration)
    {
        powerupName = _name;
        powerupDuration = _duration;
        originalDuration = _duration;
    }
    public void CountDown()
    {
        powerupDuration -= Time.deltaTime;
        if (powerupDuration <= 0)
        {
            powerupDuration = originalDuration;
            isActive = false;
            Debug.Log(powerupName+" is not active");
        }
    }
}

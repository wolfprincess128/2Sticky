using UnityEngine;

public class powerupTest {
    public string powerupName;
    public float powerupDuration;

    public powerupTest() { }
    public powerupTest(string newName, float startingTime)
    {
        powerupName = newName;
        powerupDuration = startingTime;
    }
}
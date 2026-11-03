using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int HP = 3;
    public bool isInvincible;
    public void takeDamage(int _damage)
    {
        if (!isInvincible)
        {
            HP = HP - _damage;
        }
    }
}

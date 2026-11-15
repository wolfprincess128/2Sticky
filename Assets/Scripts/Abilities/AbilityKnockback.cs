using UnityEngine;

public class AbilityKnockback : Ability
{
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackLength;

    protected override void ApplyEffect(GameObject target)
    {
        EnemyBlob enemy = target.GetComponentInParent<EnemyBlob>();

        if (enemy != null)
        {
            enemy.DoKnockback(knockbackForce, knockbackLength);
        }
    }
}

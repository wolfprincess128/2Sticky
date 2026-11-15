using UnityEngine;

public class AbilityPoison : Ability
{
[SerializeField] private float poisonDamage;
[SerializeField] private float poisonTime;

protected override void ApplyEffect(GameObject target)
{
    EnemyBlob enemy = target.GetComponentInParent<EnemyBlob>();

    if (enemy != null)
    {
        enemy.DoPoison(poisonTime, poisonDamage);
    }
}

}

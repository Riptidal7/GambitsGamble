using System;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Transform AttackPoint;
    public LayerMask EnemyLayers;
    public float AttackRange = GameParameters.AttackRange;

    public void MakeMeleeAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            print("I hit a guy!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}

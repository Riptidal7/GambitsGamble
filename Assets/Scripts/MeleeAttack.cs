using System;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Transform AttackPoint;
    public LayerMask EnemyLayers;
    public float AttackRange = GameParameters.AttackRange;


    public void MakeMeleeAttack()
    {
        Debug.Log("Melee attack triggered!");

        if (AttackPoint == null)
        {
            Debug.LogWarning("AttackPoint is not assigned.");
            return;
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log($"Hit enemy: {enemy.name}");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}

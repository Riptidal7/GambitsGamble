using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellParent : MonoBehaviour
{
    [NonSerialized]
    public int SpellFlatDamage;
    public int MaxEnemiesToHit = int.MaxValue;

    protected HashSet<GameObject> enemiesHit = new HashSet<GameObject>();
    protected List<Enemy> enemyComponentsHit = new List<Enemy>();

    protected virtual void Start()
    {
        StartCoroutine(CountdownUntilDisappear());
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (enemiesHit.Count >= MaxEnemiesToHit)
            return;
        
        GameObject target = other.gameObject;

        if (enemiesHit.Contains(target))
            return;

        Enemy enemyComponent = target.GetComponent<Enemy>();
        if (enemyComponent != null)
        {
            enemyComponent.HitPoints -= SpellFlatDamage;
            enemiesHit.Add(target);
            enemyComponentsHit.Add(enemyComponent);
            OnEnemyHit(enemyComponent); // Extension point for child classes
        }
    }

    protected virtual void OnEnemyHit(Enemy enemy)
    {
        // Optional override in child class
    }

    IEnumerator CountdownUntilDisappear()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
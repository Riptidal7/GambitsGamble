using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellParent : MonoBehaviour
{
    [NonSerialized]
    public int SpellFlatDamage;
    public int MaxEnemiesToHit = int.MaxValue;

    protected virtual int SpellDuration => 1;

    protected HashSet<GameObject> enemiesHit = new HashSet<GameObject>();
    protected List<Enemy> enemyComponentsHit = new List<Enemy>();

    protected virtual void Start()
    {
        StartCoroutine(CountdownUntilDisappear(SpellDuration));
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

    protected virtual IEnumerator CountdownUntilDisappear(int spellLength)
    {
        yield return new WaitForSeconds(spellLength);
        Destroy(gameObject);
    }
}
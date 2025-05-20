using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LightningSpell2 : SpellParent
{
    private List<Enemy> potentialTargets = new List<Enemy>();
    private List<GameObject> potentialTargetObjects = new List<GameObject>();
    private bool selectionStarted = false;

    protected override void Start()
    {
        SpellFlatDamage = GameParameters.LightningSpell2Damage;
        MaxEnemiesToHit = GameParameters.Lightning2EnemiesHit;
        base.Start();

        // Start selection shortly after spawn to allow OnTriggerStay2D to populate
        StartCoroutine(HitRandomEnemiesAfterDelay(0.1f));
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (selectionStarted)
            return;

        GameObject target = other.gameObject;
        if (enemiesHit.Contains(target))
            return;

        Enemy enemyComponent = target.GetComponent<Enemy>();
        if (enemyComponent != null && !potentialTargetObjects.Contains(target))
        {
            potentialTargets.Add(enemyComponent);
            potentialTargetObjects.Add(target);
        }
    }

    private IEnumerator HitRandomEnemiesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        selectionStarted = true;
        
        for (int i = 0; i < MaxEnemiesToHit; i++)
        {
            int randIndex = Random.Range(0, potentialTargets.Count);
            Enemy selected = potentialTargets[randIndex];
            GameObject selectedObj = potentialTargetObjects[randIndex];

            // Deal damage
            selected.HitPoints -= SpellFlatDamage;
            enemiesHit.Add(selectedObj);
            enemyComponentsHit.Add(selected);

            OnEnemyHit(selected);

            // Prevent duplicate hits
            potentialTargets.RemoveAt(randIndex);
            potentialTargetObjects.RemoveAt(randIndex);
        }
    }

    protected override void OnEnemyHit(Enemy enemy)
    {
        enemy.struckByLightning = true;
    }
}

using UnityEngine;

public class LightningSpell : SpellParent
{
    protected override void Start()
    {
        SpellFlatDamage = GameParameters.LightningSpell1Damage;
        MaxEnemiesToHit = GameParameters.Lightning1EnemiesHit;
        base.Start();
    }
    
    protected override void OnEnemyHit(Enemy enemy)
    {
        enemy.struckByLightning = true;
    }
}

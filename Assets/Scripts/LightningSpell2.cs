using UnityEngine;

public class LightningSpell2 : SpellParent
{
    protected override void Start()
    {
        SpellFlatDamage = GameParameters.LightningSpell2Damage;
        MaxEnemiesToHit = GameParameters.Lightning2EnemiesHit;
        base.Start();
    }
}

using UnityEngine;

public class LightningSpell : SpellParent
{
    protected override void Start()
    {
        SpellFlatDamage = GameParameters.LightningSpell1Damage;
        base.Start();
    }
}

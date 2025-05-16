using UnityEngine;

public class AttackBuffSpell : SpellParent
{
    
    protected override int SpellDuration => GameParameters.AttackBuff1Length;
    
    void Start()
    {
        SpellFlatDamage = GameParameters.MeleeAttackDamage;
        GameParameters.MeleeAttackDamage += 3;
        Debug.Log("Powering up!");
        base.Start();
        Debug.Log("Powering down :(");
        GameParameters.MeleeAttackDamage = SpellFlatDamage;
    }

    
}

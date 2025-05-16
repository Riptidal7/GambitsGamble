using System.Collections;
using UnityEngine;

public class AttackBuffSpell : SpellParent
{
    
    protected override int SpellDuration => GameParameters.AttackBuff1Length;
    public int OriginalAttack = GameParameters.MeleeAttackDamage;
    
    void Start()
    {
        GameParameters.MeleeAttackDamage += 3;
        base.Start();
    }
    
    protected override IEnumerator CountdownUntilDisappear(int spellLength)
    {
        yield return new WaitForSeconds(spellLength);
        Destroy(gameObject);
        GameParameters.MeleeAttackDamage = OriginalAttack;
    }

    
}

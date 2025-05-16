using System.Collections;
using UnityEngine;

public class AttackSpell2 : SpellParent
{
    protected override int SpellDuration => GameParameters.AttackBuff2Length;
    public int OriginalAttack = GameParameters.MeleeAttackDamage;
    
    void Start()
    {
        GameParameters.MeleeAttackDamage += 5;
        base.Start();
    }
    
    protected override IEnumerator CountdownUntilDisappear(int spellLength)
    {
        yield return new WaitForSeconds(spellLength);
        Destroy(gameObject);
        GameParameters.MeleeAttackDamage = OriginalAttack;
    }
}

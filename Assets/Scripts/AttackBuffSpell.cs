using UnityEngine;

public class AttackBuffSpell : SpellParent
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpellFlatDamage = GameParameters.MeleeAttackDamage;
        GameParameters.MeleeAttackDamage += 3;
        Debug.Log("Powering up!");
        base.Start();
        Debug.Log("Powering down :(");
        GameParameters.MeleeAttackDamage = SpellFlatDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

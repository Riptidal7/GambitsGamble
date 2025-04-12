using System;
using System.Collections;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public DiceRoller DiceRoller;
    public HealSpell HealSpell;

    public void CastTheSpell(int SpellOnDie)
    {
        if (DiceRoller.CanICast)
        {
            CastAtSlotOnDie(SpellOnDie);
            DiceRoller.CanICast = false;
        }
        else
        {
            return;
        }
    }
    public void CastAtSlotOnDie(int SpellOnDie)
    {
        if (SpellOnDie == 0)
        {
            HealSpell.CastHealSpellFirstLevel();
            print("Healing");
        }
        if (SpellOnDie == 1)
        {
            HealSpell.CastHealSpellFirstLevel();
            print("Healing");
        }
        if (SpellOnDie == 2)
        {
            print("I... AM STEVE");
        }
        if (SpellOnDie == 3)
        {
            print("Mrowr :3");
        }
        if (SpellOnDie == 4)
        {
            print("MARIA!!!!!!!");
        }
        if (SpellOnDie == 5)
        {
            print("Shimp");
        }
    }

    
    
}

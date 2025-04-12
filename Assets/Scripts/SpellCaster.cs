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
            // Boss Baby
            HealSpell.CastHealSpellFirstLevel();
        }
        if (SpellOnDie == 1)
        {
            //Chicken Jockey
            HealSpell.CastHealSpellFirstLevel();
        }
        if (SpellOnDie == 2)
        {
            print("Minecraft Steve Image");
        }
        if (SpellOnDie == 3)
        {
            print("Kitty Image");
        }
        if (SpellOnDie == 4)
        {
            print("Shadow Image");
        }
        if (SpellOnDie == 5)
        {
            print("Shrimp Image");
        }
    }

    
    
}

using System;
using System.Collections;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public DiceRoller DiceRoller;
    public Player Gambit;
    public GameObject fireSpellPrefab;
    public GameObject iceSpellPrefab;
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
            GameObject fireBall= Instantiate(fireSpellPrefab, Gambit.transform.position, Quaternion.identity);
            fireBall.transform.SetParent(Gambit.transform);
        }
        if (SpellOnDie == 3)
        {
            print("Mrowr :3");
            GameObject iceAoE= Instantiate(iceSpellPrefab, Gambit.transform.position, Quaternion.identity);
            iceAoE.transform.SetParent(Gambit.transform);
        }
        if (SpellOnDie == 4)
        {
            print("MARIA!!!!!!!");
            GameObject iceAoE= Instantiate(iceSpellPrefab, Gambit.transform.position, Quaternion.identity);
            iceAoE.transform.SetParent(Gambit.transform);
        }
        if (SpellOnDie == 5)
        {
            print("Shimp");
            GameObject iceAoE= Instantiate(iceSpellPrefab, Gambit.transform.position, Quaternion.identity);
            iceAoE.transform.SetParent(Gambit.transform);
        }
    }

    
    
}

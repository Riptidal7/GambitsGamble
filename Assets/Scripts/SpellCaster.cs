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

    public Action SlotOneCast;
    public Action SlotTwoCast;
    public Action SlotThreeCast;
    public Action SlotFourCast;
    public Action SlotFiveCast;
    public Action SlotSixCast;

    void Start()
    {
        SlotOneCast = new Action(()=>CastFire());
        SlotTwoCast = new Action(() => CastFire());
        SlotThreeCast = new Action(() => {});
        SlotFourCast = new Action(() => { });
        SlotFiveCast = new Action(() => { });
        SlotSixCast = new Action(() => { });
    }
    
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
           CastOnSlotOne();
        }
        if (SpellOnDie == 1)
        {
            CastOnSlotTwo();
        }
        if (SpellOnDie == 2)
        {
           CastOnSlotThree();
        }
        if (SpellOnDie == 3)
        {
            CastOnSlotFour();
        }
        if (SpellOnDie == 4)
        {
            CastOnSlotFive();
        }
        if (SpellOnDie == 5)
        {
            CastOnSlotSix();
        }
    }

    private void CastOnSlotOne()
    {
        SlotOneCast();
    }
    private void CastOnSlotTwo()
    {
        SlotTwoCast();
    }

    private void CastOnSlotThree()
    {
        SlotThreeCast();
    }
    
    private void CastOnSlotFour()
    {
        SlotFourCast();
    }
    
    private void CastOnSlotFive()
    {
        SlotFiveCast();
    }
    
    private void CastOnSlotSix()
    {
        SlotSixCast();
    }

    public void CastFire()
    {
        GameObject fireBall= Instantiate(fireSpellPrefab, Gambit.transform.position, Quaternion.identity);
        fireBall.transform.SetParent(Gambit.transform);
    }

    public void CastIce()
    {
        GameObject iceAoE= Instantiate(iceSpellPrefab, Gambit.transform.position, Quaternion.identity);
        iceAoE.transform.SetParent(Gambit.transform);
    }

    public void CastHeal()
    {
        HealSpell.CastHealSpellFirstLevel();
    }
    
    
}

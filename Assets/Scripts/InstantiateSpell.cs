using System;
using System.Collections;
using UnityEngine;

public class InstantiateSpell : MonoBehaviour
{
    public DiceRoller DiceRoller;
    public Player Gambit;
    
    public GameObject fireSpellPrefab;
    public GameObject fireSpell2Prefab;
    
    public GameObject iceSpellPrefab;
    public GameObject iceSpell2Prefab;
    
    public HealSpell HealSpell;
    public GameObject healAnimation;
    
    public Action SlotOneCast;
    public Action SlotTwoCast;
    public Action SlotThreeCast;
    public Action SlotFourCast;
    public Action SlotFiveCast;
    public Action SlotSixCast;

    void Start()
    {
        SlotOneCast = new Action(()=> {});
        SlotTwoCast = new Action(() => {});
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
           SlotOneCast();
        }
        if (SpellOnDie == 1)
        {
            SlotTwoCast();
        }
        if (SpellOnDie == 2)
        {
           SlotThreeCast();
        }
        if (SpellOnDie == 3)
        {
            SlotFourCast();
        }
        if (SpellOnDie == 4)
        {
            SlotFiveCast();
        }
        if (SpellOnDie == 5)
        {
            SlotSixCast();
        }
    }
    
    public void CastNothing()
    {
        SFXManager.Play("FailedDiceRoll1");
    }

    public void InstantiateFire1()
    {
        GameObject fireBall= Instantiate(fireSpellPrefab, Gambit.transform.position, Quaternion.identity);
        fireBall.transform.SetParent(Gambit.transform);
        SFXManager.Play("FireSpell");
    }

    public void InstantiateFire2()
    {
        GameObject fireBall2= Instantiate(fireSpell2Prefab, Gambit.transform.position, Quaternion.identity);
        fireBall2.transform.SetParent(Gambit.transform);
        SFXManager.Play("Explosion");
    }
    
    public void CastFire3()
    {
        
    }
   
    public void InstantiateHeal1()
    {
        HealSpell.HealAmount = GameParameters.HealSpell1Heal;
        HealSpell.HealPlayer();
        InstantiateHealAnimation();
        SFXManager.Play("HealSpell");
    }
    
    public void InstantiateHeal2()
    {
        HealSpell.HealAmount = GameParameters.HealSpell2Heal;
        HealSpell.HealPlayer();
        InstantiateHealAnimation();
        SFXManager.Play("HealSpell");
    }

    public void CastHeal3()
    {
        
    }

    private void InstantiateHealAnimation()
    {
        GameObject heal = Instantiate(healAnimation, Gambit.transform.position, Quaternion.identity);
        heal.transform.SetParent(Gambit.transform);
        StartCoroutine(CountdownUntilHealAnimationOver(heal));
    }
    
    IEnumerator CountdownUntilHealAnimationOver(GameObject healToDestroy)
    {
        yield return new WaitForSeconds(1);
        Destroy(healToDestroy);
    }
    public void InstantiateIce1()
    {
        GameObject iceAoE= Instantiate(iceSpellPrefab, Gambit.transform.position, Quaternion.identity);
        iceAoE.transform.SetParent(Gambit.transform);
        SFXManager.Play("IceSpell");
    }

    public void InstantiateIce2()
    {
        GameObject iceAoE2= Instantiate(iceSpell2Prefab, Gambit.transform.position, Quaternion.identity);
        iceAoE2.transform.SetParent(Gambit.transform);
        SFXManager.Play("IceSpell");
    }

    public void CastIce3()
    {
        
    }

  


}

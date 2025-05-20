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
    
    public GameObject lightningSpellPrefab;
    public GameObject lightningSpell2Prefab;

    public GameObject attackSpellPrefab;
    public GameObject attackSpell2Prefab;
    
    public GameObject windSpellPrefab;
    public GameObject windSpell2Prefab;
    
    
    public HealSpell HealSpell;
    public GameObject healAnimation;
    public DamageHandler damageHandler;
    
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
        if (DiceRoller.CanICast && DiceRoller.StillImage.activeSelf) // can only cast when the spell image is onscreen
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

    public void InstantiateASpell(GameObject spellPrefab, string spellSoundEffectName)
    {
        GameObject spell = Instantiate(spellPrefab, Gambit.transform.position, Quaternion.identity);
        damageHandler = GameObject.FindWithTag("Handler").GetComponent<DamageHandler>();
        spell.transform.SetParent(Gambit.transform);
        SFXManager.Play(spellSoundEffectName);
    }

    public void InstantiateFire1()
    {
        InstantiateASpell(fireSpellPrefab, "FireSpell");
    }

    public void InstantiateFire2()
    {
        InstantiateASpell(fireSpellPrefab, "Explosion");
    }
    
    public void InstantiateIce1()
    {
        InstantiateASpell(iceSpellPrefab, "IceSpell");
    }

    public void InstantiateIce2()
    {
        InstantiateASpell(iceSpell2Prefab, "IceSpell");
    }

    public void InstantiateLightning1()
    {
        InstantiateASpell(lightningSpellPrefab, "Explosion");
    }

    public void InstantiateLightning2()
    {
        InstantiateASpell(lightningSpell2Prefab, "Explosion");
    }

    public void InstantiateAttackBuff1()
    {
        InstantiateASpell(attackSpellPrefab, "Explosion");
    }
    
    public void InstantiateAttackBuff2()
    {
        InstantiateASpell(attackSpell2Prefab, "Explosion");
    }

    public void InstantiateWind1()
    {
        InstantiateASpell(windSpellPrefab, "IceSpell");
    }
    
    public void InstantiateWind2()
    {
        InstantiateASpell(windSpell2Prefab, "IceSpell");
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
    

  


}

using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


public class DiceFaceChoiceMenu : MonoBehaviour
{
    
    
    public Sprite IconIceSpell;
    public Sprite IconFireSpell;
    public Sprite IconHealSpell;

    public Sprite IconFire2Spell;
    public Sprite IconIce2Spell;
    public Sprite IconHeal2Spell;
    
    public Image DiceFace1Image;
    public Image DiceFace2Image;
    public Image DiceFace3Image;
    public Image DiceFace4Image;
    public Image DiceFace5Image;
    public Image DiceFace6Image;

    public string currentSpellSlot1;
    public string currentSpellSlot2;
    public string currentSpellSlot3;
    public string currentSpellSlot4;
    public string currentSpellSlot5;
    public string currentSpellSlot6;
    
    public string spellToBeApplied;
    public SpellCaster spellCaster;
    public WaveManager waveManager;
    public DiceRoller diceRoller;
 
    public CanvasGroup DiceFaceChoiceMenuPanel;
    
    void Start()
    {
        StartHideDiceFaceChoiceMenu();
    }
 
    public void ShowDiceFaceChoiceMenu()
    {
        CanvasGroupDisplayer.Show(DiceFaceChoiceMenuPanel);
    }
    public void HideDiceFaceChoiceMenu()
    {
        CanvasGroupDisplayer.Hide(DiceFaceChoiceMenuPanel);
        waveManager.GenerateNewWave();
        waveManager.waveClearedSwitch = false;
    }

    private void StartHideDiceFaceChoiceMenu()
    { 
        CanvasGroupDisplayer.Hide(DiceFaceChoiceMenuPanel);
    }


 
    public void OnFaceChoice1Clicked()
    {
        if (spellToBeApplied=="Fire Spell")
        {
            if (currentSpellSlot1 == spellToBeApplied)
            {
                DiceFace1Image.sprite = IconFire2Spell;
                diceRoller.DieRollSprites[0] = IconFire2Spell;
                spellCaster.SlotOneCast = new Action(() => spellCaster.CastFire2());
            }
            else
            {
                DiceFace1Image.sprite = IconFireSpell;
                diceRoller.DieRollSprites[0] = IconFireSpell;
                spellCaster.SlotOneCast = new Action(() => spellCaster.CastFire());
            }
        }
        
        else if (spellToBeApplied == "Ice Spell")
        {
            if (currentSpellSlot1 == spellToBeApplied)
            {
                DiceFace1Image.sprite = IconIce2Spell;
                diceRoller.DieRollSprites[0] = IconIce2Spell;
                spellCaster.SlotOneCast = new Action(() => spellCaster.CastIce2());
            }

            else
            {
                DiceFace1Image.sprite = IconIceSpell;
                diceRoller.DieRollSprites[0] = IconIceSpell;
                spellCaster.SlotOneCast = new Action(() => spellCaster.CastIce());
            }
        }
        
        else if (spellToBeApplied == "Heal Spell")
        {
            if (currentSpellSlot1 == spellToBeApplied)
            {
                DiceFace1Image.sprite = IconHeal2Spell;
                diceRoller.DieRollSprites[0] = IconHeal2Spell;
                spellCaster.SlotOneCast = new Action(() => spellCaster.CastHeal2());
            }
            else
            {
                DiceFace1Image.sprite = IconHealSpell;
                diceRoller.DieRollSprites[0] = IconHealSpell;
                spellCaster.SlotOneCast = new Action(() => spellCaster.CastHeal());
            }
        }

        else
        {
            print("spell to be applied does not exist");
        }

        currentSpellSlot1 = spellToBeApplied;
        //print("currentSpell: " + currentSpellSlot1);
        StartCoroutine(MenuSelectDelay());
    }
 
    public void OnFaceChoice2Clicked()
    {
        if (spellToBeApplied=="Fire Spell")
        {
            if (currentSpellSlot2 == spellToBeApplied)
            {
                DiceFace2Image.sprite = IconFire2Spell;
                diceRoller.DieRollSprites[1] = IconFire2Spell;
                spellCaster.SlotTwoCast = new Action(() => spellCaster.CastFire2());
            }
            else
            {
                DiceFace2Image.sprite = IconFireSpell;
                diceRoller.DieRollSprites[1] = IconFireSpell;
                spellCaster.SlotTwoCast = new Action(() => spellCaster.CastFire());
            }
        }
        
        else if (spellToBeApplied == "Ice Spell")
        {
            if (currentSpellSlot2 == spellToBeApplied)
            {
                DiceFace2Image.sprite = IconIce2Spell;
                diceRoller.DieRollSprites[1] = IconIce2Spell;
                spellCaster.SlotTwoCast = new Action(() => spellCaster.CastIce2());
            }

            else
            {
                DiceFace2Image.sprite = IconIceSpell;
                diceRoller.DieRollSprites[1] = IconIceSpell;
                spellCaster.SlotTwoCast = new Action(() => spellCaster.CastIce());
            }
        }
        
        else if (spellToBeApplied == "Heal Spell")
        {
            if (currentSpellSlot2 == spellToBeApplied)
            {
                DiceFace2Image.sprite = IconHeal2Spell;
                diceRoller.DieRollSprites[1] = IconHeal2Spell;
                spellCaster.SlotTwoCast = new Action(() => spellCaster.CastHeal2());
            }
            else
            {
                DiceFace2Image.sprite = IconHealSpell;
                diceRoller.DieRollSprites[1] = IconHealSpell;
                spellCaster.SlotTwoCast = new Action(() => spellCaster.CastHeal());
            }
           
        }

        else
        {
            print("spell to be applied does not exist");
        }
        currentSpellSlot2 = spellToBeApplied;
    //    print("currentSpell: " + currentSpellSlot2);
        StartCoroutine(MenuSelectDelay());
    }
 
    public void OnFaceChoice3Clicked()
    {
        if (spellToBeApplied=="Fire Spell")
        {
            if (currentSpellSlot3 == spellToBeApplied)
            {
                DiceFace3Image.sprite = IconFire2Spell;
                diceRoller.DieRollSprites[2] = IconFire2Spell;
                spellCaster.SlotThreeCast = new Action(() => spellCaster.CastFire2());
            }
            else
            {
                
                DiceFace3Image.sprite = IconFireSpell;
                diceRoller.DieRollSprites[2] = IconFireSpell;
                spellCaster.SlotThreeCast = new Action(() => spellCaster.CastFire());
            }
        }
        
        else if (spellToBeApplied == "Ice Spell")
        {
            if (currentSpellSlot3 == spellToBeApplied)
            {
                DiceFace3Image.sprite = IconIce2Spell;
                diceRoller.DieRollSprites[2] = IconIce2Spell;
                spellCaster.SlotThreeCast = new Action(() => spellCaster.CastIce2());
            }

            else
            {
                DiceFace3Image.sprite = IconIceSpell;
                diceRoller.DieRollSprites[2] = IconIceSpell;
                spellCaster.SlotThreeCast = new Action(() => spellCaster.CastIce());
            }
        }
        
        else if (spellToBeApplied == "Heal Spell")
        {
            if (currentSpellSlot3 == spellToBeApplied)
            {
                DiceFace3Image.sprite = IconHeal2Spell;
                diceRoller.DieRollSprites[2] = IconHeal2Spell;
                spellCaster.SlotThreeCast = new Action(() => spellCaster.CastHeal2());
            }
            else
            {
                DiceFace3Image.sprite = IconHealSpell;
                diceRoller.DieRollSprites[2] = IconHealSpell;
                spellCaster.SlotThreeCast = new Action(() => spellCaster.CastHeal());
            }
        }

        else
        {
            print("spell to be applied does not exist");
        }
        currentSpellSlot3 = spellToBeApplied;
    //    print("currentSpell: " + currentSpellSlot3);
        StartCoroutine(MenuSelectDelay());
    }
 
    public void OnFaceChoice4Clicked()
    {
        if (spellToBeApplied=="Fire Spell")
        {
            if (currentSpellSlot4 == spellToBeApplied)
            {
                DiceFace4Image.sprite = IconFire2Spell;
                diceRoller.DieRollSprites[3] = IconFire2Spell;
                spellCaster.SlotFourCast = new Action(() => spellCaster.CastFire2());
            }

            else 
            {
                DiceFace4Image.sprite = IconFireSpell;
                diceRoller.DieRollSprites[3] = IconFireSpell;
                spellCaster.SlotFourCast = new Action(() => spellCaster.CastFire());
            }
        }
        
        else if (spellToBeApplied == "Ice Spell")
        {
            if (currentSpellSlot4 == spellToBeApplied)
            {
                DiceFace4Image.sprite = IconIce2Spell;
                diceRoller.DieRollSprites[3] = IconIce2Spell;
                spellCaster.SlotFourCast = new Action(() => spellCaster.CastIce2());
            }

            else
            {
                DiceFace4Image.sprite = IconIceSpell;
                diceRoller.DieRollSprites[3] = IconIceSpell;
                spellCaster.SlotFourCast = new Action(() => spellCaster.CastIce());
            }
        }
        
        else if (spellToBeApplied == "Heal Spell")
        {
            if (currentSpellSlot4 == spellToBeApplied)
            {
                DiceFace4Image.sprite = IconHeal2Spell;
                diceRoller.DieRollSprites[3] = IconHeal2Spell;
                spellCaster.SlotFourCast = new Action(() => spellCaster.CastHeal2());
            }
            else
            {
                DiceFace4Image.sprite = IconHealSpell;
                diceRoller.DieRollSprites[3] = IconHealSpell;
                spellCaster.SlotFourCast = new Action(() => spellCaster.CastHeal());
            }
        }

        else
        {
            print("spell to be applied does not exist");
        }
        currentSpellSlot4 = spellToBeApplied;
      //  print("currentSpell: " + currentSpellSlot4);
      StartCoroutine(MenuSelectDelay());
    }
 
    public void OnFaceChoice5Clicked()
    {
        if (spellToBeApplied=="Fire Spell")
        {
            if (currentSpellSlot5 == spellToBeApplied)
            {
                DiceFace5Image.sprite = IconFire2Spell;
                diceRoller.DieRollSprites[4] = IconFire2Spell;
                spellCaster.SlotFiveCast = new Action(() => spellCaster.CastFire2());
            }

            else
            {
                DiceFace5Image.sprite = IconFireSpell;
                diceRoller.DieRollSprites[4] = IconFireSpell;
                spellCaster.SlotFiveCast = new Action(() => spellCaster.CastFire());
            }
        }
        
        else if (spellToBeApplied == "Ice Spell")
        {
            if (currentSpellSlot5 == spellToBeApplied)
            {
                DiceFace5Image.sprite = IconIce2Spell;
                diceRoller.DieRollSprites[4] = IconIce2Spell;
                spellCaster.SlotFiveCast = new Action(() => spellCaster.CastIce2());
            }
            else
            {
                DiceFace5Image.sprite = IconIceSpell;
                diceRoller.DieRollSprites[4] = IconIceSpell;
                spellCaster.SlotFiveCast = new Action(() => spellCaster.CastIce());
            }
        }
        
        else if (spellToBeApplied == "Heal Spell")
        {
            if (currentSpellSlot5 == spellToBeApplied)
            {
                DiceFace5Image.sprite = IconHeal2Spell;
                diceRoller.DieRollSprites[4] = IconHeal2Spell;
                spellCaster.SlotFiveCast = new Action(() => spellCaster.CastHeal2());
            }
            else
            {
                DiceFace5Image.sprite = IconHealSpell;
                diceRoller.DieRollSprites[4] = IconHealSpell;
                spellCaster.SlotFiveCast = new Action(() => spellCaster.CastHeal());
            }
        }

        else
        {
            print("spell to be applied does not exist");
        }
        currentSpellSlot5 = spellToBeApplied;
       // print("currentSpell: " + currentSpellSlot5);
       StartCoroutine(MenuSelectDelay());
    }
 
    public void OnFaceChoice6Clicked()
    {
        if (spellToBeApplied=="Fire Spell")
        {
            if (currentSpellSlot6 == spellToBeApplied)
            {
                DiceFace6Image.sprite = IconFire2Spell;
                diceRoller.DieRollSprites[5] = IconFire2Spell;
                spellCaster.SlotSixCast = new Action(() => spellCaster.CastFire2());
            }

            else
            {
                DiceFace6Image.sprite = IconFireSpell;
                diceRoller.DieRollSprites[5] = IconFireSpell;
                spellCaster.SlotSixCast = new Action(() => spellCaster.CastFire());
            }
        }
        
        else if (spellToBeApplied == "Ice Spell")
        {
            if (currentSpellSlot6 == spellToBeApplied)
            {
                DiceFace6Image.sprite = IconIce2Spell;
                diceRoller.DieRollSprites[5] = IconIce2Spell;
                spellCaster.SlotSixCast = new Action(() => spellCaster.CastIce2());
            }

            else
            {
                DiceFace6Image.sprite = IconIceSpell;
                diceRoller.DieRollSprites[5] = IconIceSpell;
                spellCaster.SlotSixCast = new Action(() => spellCaster.CastIce());
            }
        }
        
        else if (spellToBeApplied == "Heal Spell")
        {
            if (currentSpellSlot6 == spellToBeApplied)
            {
                DiceFace6Image.sprite = IconHeal2Spell;
                diceRoller.DieRollSprites[5] = IconHeal2Spell;
                spellCaster.SlotFiveCast = new Action(() => spellCaster.CastHeal2());
            }
            else
            {
                DiceFace6Image.sprite = IconHealSpell;
                diceRoller.DieRollSprites[5] = IconHealSpell;
                spellCaster.SlotSixCast = new Action(() => spellCaster.CastHeal());
            }
        }

        else
        {
            print("spell to be applied does not exist");
        }
        currentSpellSlot6 = spellToBeApplied;
       // print("currentSpell: " + currentSpellSlot6);
       StartCoroutine(MenuSelectDelay());
    }

    IEnumerator MenuSelectDelay()
    {
        yield return new WaitForSeconds(1);
        HideDiceFaceChoiceMenu();
    }
}
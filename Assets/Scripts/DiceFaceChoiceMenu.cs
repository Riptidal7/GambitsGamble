using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


public class DiceFaceChoiceMenu : MonoBehaviour
{
    
    
    public Sprite IconIceSpell;
    public Sprite IconFireSpell;
    public Sprite IconHealSpell;
    
    public Image DiceFace1Image;
    public Image DiceFace2Image;
    public Image DiceFace3Image;
    public Image DiceFace4Image;
    public Image DiceFace5Image;
    public Image DiceFace6Image;

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
            DiceFace1Image.sprite = IconFireSpell;
            diceRoller.DieRollSprites[0] = IconFireSpell;
            spellCaster.SlotOneCast = new Action(() => spellCaster.CastFire());
        }
        
        else if (spellToBeApplied == "Ice Spell")
        {
            DiceFace1Image.sprite = IconIceSpell;
            diceRoller.DieRollSprites[0] = IconIceSpell;
            spellCaster.SlotOneCast = new Action(() => spellCaster.CastIce());
        }
        
        else if (spellToBeApplied == "Heal Spell")
        {
            DiceFace1Image.sprite = IconHealSpell;
            diceRoller.DieRollSprites[0] = IconHealSpell;
            spellCaster.SlotOneCast = new Action(() => spellCaster.CastHeal());
        }

        else
        {
            print("spell to be applied does not exist");
        }
        HideDiceFaceChoiceMenu();
    }
 
    public void OnFaceChoice2Clicked()
    {
        if (spellToBeApplied=="Fire Spell")
        {
            DiceFace2Image.sprite = IconFireSpell;
            diceRoller.DieRollSprites[1] = IconFireSpell;
            spellCaster.SlotTwoCast = new Action(() => spellCaster.CastFire());
        }
        
        else if (spellToBeApplied == "Ice Spell")
        {
            DiceFace2Image.sprite = IconIceSpell;
            diceRoller.DieRollSprites[1] = IconIceSpell;
            spellCaster.SlotTwoCast = new Action(() => spellCaster.CastIce());
        }
        
        else if (spellToBeApplied == "Heal Spell")
        {
            DiceFace2Image.sprite = IconHealSpell;
            diceRoller.DieRollSprites[1] = IconHealSpell;
            spellCaster.SlotTwoCast = new Action(() => spellCaster.CastHeal());
        }

        else
        {
            print("spell to be applied does not exist");
        }
        HideDiceFaceChoiceMenu();
    }
 
    public void OnFaceChoice3Clicked()
    {
        if (spellToBeApplied=="Fire Spell")
        {
            DiceFace3Image.sprite = IconFireSpell;
            diceRoller.DieRollSprites[2] = IconFireSpell;
            spellCaster.SlotThreeCast = new Action(() => spellCaster.CastFire());
        }
        
        else if (spellToBeApplied == "Ice Spell")
        {
            DiceFace3Image.sprite = IconIceSpell;
            diceRoller.DieRollSprites[2] = IconIceSpell;
            spellCaster.SlotThreeCast = new Action(() => spellCaster.CastIce());
        }
        
        else if (spellToBeApplied == "Heal Spell")
        {
            DiceFace3Image.sprite = IconHealSpell;
            diceRoller.DieRollSprites[2] = IconHealSpell;
            spellCaster.SlotThreeCast = new Action(() => spellCaster.CastHeal());
        }

        else
        {
            print("spell to be applied does not exist");
        }
        HideDiceFaceChoiceMenu();
    }
 
    public void OnFaceChoice4Clicked()
    {
        if (spellToBeApplied=="Fire Spell")
        {
            DiceFace4Image.sprite = IconFireSpell;
            diceRoller.DieRollSprites[3] = IconFireSpell;
            spellCaster.SlotFourCast = new Action(() => spellCaster.CastFire());
        }
        
        else if (spellToBeApplied == "Ice Spell")
        {
            DiceFace4Image.sprite = IconIceSpell;
            diceRoller.DieRollSprites[3] = IconIceSpell;
            spellCaster.SlotFourCast = new Action(() => spellCaster.CastIce());
        }
        
        else if (spellToBeApplied == "Heal Spell")
        {
            DiceFace4Image.sprite = IconHealSpell;
            diceRoller.DieRollSprites[3] = IconHealSpell;
            spellCaster.SlotFourCast = new Action(() => spellCaster.CastHeal());
        }

        else
        {
            print("spell to be applied does not exist");
        }
        
        HideDiceFaceChoiceMenu();
    }
 
    public void OnFaceChoice5Clicked()
    {
        if (spellToBeApplied=="Fire Spell")
        {
            DiceFace5Image.sprite = IconFireSpell;
            diceRoller.DieRollSprites[4] = IconFireSpell;
            spellCaster.SlotFiveCast = new Action(() => spellCaster.CastFire());
        }
        
        else if (spellToBeApplied == "Ice Spell")
        {
            DiceFace5Image.sprite = IconIceSpell;
            diceRoller.DieRollSprites[4] = IconIceSpell;
            spellCaster.SlotFiveCast = new Action(() => spellCaster.CastIce());
        }
        
        else if (spellToBeApplied == "Heal Spell")
        {
            DiceFace5Image.sprite = IconHealSpell;
            diceRoller.DieRollSprites[4] = IconHealSpell;
            spellCaster.SlotFiveCast = new Action(() => spellCaster.CastHeal());
        }

        else
        {
            print("spell to be applied does not exist");
        }
        
        HideDiceFaceChoiceMenu();
    }
 
    public void OnFaceChoice6Clicked()
    {
        if (spellToBeApplied=="Fire Spell")
        {
            DiceFace6Image.sprite = IconFireSpell;
            diceRoller.DieRollSprites[5] = IconFireSpell;
            spellCaster.SlotSixCast = new Action(() => spellCaster.CastFire());
        }
        
        else if (spellToBeApplied == "Ice Spell")
        {
            DiceFace6Image.sprite = IconIceSpell;
            diceRoller.DieRollSprites[5] = IconIceSpell;
            spellCaster.SlotSixCast = new Action(() => spellCaster.CastIce());
        }
        
        else if (spellToBeApplied == "Heal Spell")
        {
            DiceFace6Image.sprite = IconHealSpell;
            diceRoller.DieRollSprites[5] = IconHealSpell;
            spellCaster.SlotSixCast = new Action(() => spellCaster.CastHeal());
        }

        else
        {
            print("spell to be applied does not exist");
        }
        
        HideDiceFaceChoiceMenu();
    }
}
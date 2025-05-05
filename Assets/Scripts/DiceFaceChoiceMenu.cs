using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


public class DiceFaceChoiceMenu : MonoBehaviour
{


    public List<Image> diceFaceImages;
    public List<string> currentSpellSlots;
    public string spellToBeApplied;
    
    //dictionary that connects spell names to sprites and actions
    public Dictionary<string, Sprite> spellSprites; 
    public Dictionary<string, Action> spellActions;
    
    public Sprite IconFireSpell;
    public Sprite IconFire2Spell;
    public Sprite IconIceSpell;
    public Sprite IconIce2Spell;
    public Sprite IconHealSpell;
    public Sprite IconHeal2Spell;
    
  
   public Image DiceFace1Image;
   public Image DiceFace2Image;
   public Image DiceFace3Image;
   public Image DiceFace4Image;
   public Image DiceFace5Image;
   public Image DiceFace6Image;
/*

   //remove below if code is working
   public string currentSpellSlot1;
   public string currentSpellSlot2;
   public string currentSpellSlot3;
   public string currentSpellSlot4;
   public string currentSpellSlot5;
   public string currentSpellSlot6;
   //remove above if code works

   */
    
    public SpellCaster spellCaster;
    public WaveManager waveManager;
    public DiceRoller diceRoller;

    public PowerUpChoiceMenu powerUpChoiceMenu;
 
    public CanvasGroup DiceFaceChoiceMenuPanel;
    
    
    
    
    
    void Start()
    {
        InitializeDictionaries();
        diceFaceImages = new List<Image> { DiceFace1Image, DiceFace2Image, DiceFace3Image, DiceFace4Image, DiceFace5Image, DiceFace6Image };
        Debug.Log("diceFaceImages count: " + diceFaceImages.Count);
        currentSpellSlots = new List<string> { "", "", "", "", "", "" };
        StartHideDiceFaceChoiceMenu();
    }

    void InitializeDictionaries()
    {
        spellSprites = new Dictionary<string, Sprite>
        {
            { "Fire Spell", IconFireSpell },
            { "Fire Spell2", IconFire2Spell },
            { "Ice Spell", IconIceSpell },
            { "Ice Spell2", IconIce2Spell },
            { "Heal Spell", IconHealSpell },
            { "Heal Spell2", IconHeal2Spell }
        };

        spellActions = new Dictionary<string, Action>
        {
            { "Fire Spell", new Action(() => spellCaster.CastFire()) },
            { "Fire Spell2", new Action(() => spellCaster.CastFire2()) },
            { "Ice Spell", new Action(() => spellCaster.CastIce()) },
            { "Ice Spell2", new Action(() => spellCaster.CastIce2()) },
            { "Heal Spell", new Action(() => spellCaster.CastHeal1()) },
            { "Heal Spell2", new Action(() => spellCaster.CastHeal2()) }
        };
    }

    public void OnFaceChoiceClicked(int slotIndex)
{
    // Determine the spell to be applied and the corresponding spell level (standard or level 2)
    string spellKey = spellToBeApplied;
    string spellKey2 = spellToBeApplied + "2"; // For "Fire Spell2", "Ice Spell2", "Heal Spell2"

    // Check if the current slot already contains the selected spell
    bool isSameSpell = currentSpellSlots[slotIndex] == spellToBeApplied;

    // Determine which sprite to use based on whether it's the same spell or not
    Sprite selectedSprite = isSameSpell ? spellSprites[spellKey2] : spellSprites[spellKey];

    // Determine the correct spell cast action
    Action spellCastAction = isSameSpell ? spellActions[spellKey2] : spellActions[spellKey];

    // Update the dice face sprite in the appropriate slot
    diceFaceImages[slotIndex].sprite = selectedSprite;

    // Update the diceRoller DieRollSprites array with the correct sprite for the selected slot
    diceRoller.DieRollSprites[slotIndex] = selectedSprite;

    // Set the corresponding spell casting action for the correct slot
    AssignSlotCastAction(slotIndex, spellCastAction);

    // Update the current spell slot for the selected index
    currentSpellSlots[slotIndex] = spellToBeApplied;

    // Delay and hide the menu after the selection
    StartCoroutine(MenuSelectDelay());
}

void AssignSlotCastAction(int slotIndex, Action spellCastAction)
{
    switch (slotIndex)
    {
        case 0:
            spellCaster.SlotOneCast = spellCastAction;
            break;
        case 1:
            spellCaster.SlotTwoCast = spellCastAction;
            break;
        case 2:
            spellCaster.SlotThreeCast = spellCastAction;
            break;
        case 3:
            spellCaster.SlotFourCast = spellCastAction;
            break;
        case 4:
            spellCaster.SlotFiveCast = spellCastAction;
            break;
        case 5:
            spellCaster.SlotSixCast = spellCastAction;
            break;
        default:
            Debug.LogError("Invalid slot index");
            break;
    }
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
        powerUpChoiceMenu.ResumeGameAfterAllChoices();
    }

    private void StartHideDiceFaceChoiceMenu()
    { 
        CanvasGroupDisplayer.Hide(DiceFaceChoiceMenuPanel);
    }

    IEnumerator MenuSelectDelay()
    {
        yield return new WaitForSeconds(1);
        HideDiceFaceChoiceMenu();
        
        SFXManager.Play("Boon");
    }
    
}
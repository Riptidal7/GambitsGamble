using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class DiceFaceChoiceMenu : MonoBehaviour
{


    public List<Image> diceFaceImages;
    public List<string> currentSpellSlots;
    public string spellToBeApplied;
	public bool isInTutorial=false;
	public bool hasSelectedSpell=false;
    
    //dictionary that connects spell names to sprites and actions
    public Dictionary<string, Sprite> spellSprites; 
    public Dictionary<string, Action> spellActions;
    
    public bool HasBeenClicked = false;
    
    public Sprite IconFireSpell;
    public Sprite IconFire2Spell;
    public Sprite IconIceSpell;
    public Sprite IconIce2Spell;
    public Sprite IconHealSpell;
    public Sprite IconHeal2Spell;
    public Sprite IconLightningSpell;
    public Sprite IconLightning2Spell;
    
  
   public Image DiceFace1Image;
   public Image DiceFace2Image;
   public Image DiceFace3Image;
   public Image DiceFace4Image;
   public Image DiceFace5Image;
   public Image DiceFace6Image;
    
    [FormerlySerializedAs("spellInstantiator")] [FormerlySerializedAs("spellCaster")] public InstantiateSpell instantiateSpell;
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
            { "Heal Spell2", IconHeal2Spell },
            {"Lightning Spell", IconLightningSpell},
            {"Lightning Spell2", IconLightning2Spell},
        };

        spellActions = new Dictionary<string, Action>
        {
            { "Fire Spell", new Action(() => instantiateSpell.InstantiateFire1()) },
            { "Fire Spell2", new Action(() => instantiateSpell.InstantiateFire2()) },
            { "Ice Spell", new Action(() => instantiateSpell.InstantiateIce1()) },
            { "Ice Spell2", new Action(() => instantiateSpell.InstantiateIce2()) },
            { "Heal Spell", new Action(() => instantiateSpell.InstantiateHeal1()) },
            { "Heal Spell2", new Action(() => instantiateSpell.InstantiateHeal2()) },
            { "Lightning Spell", new Action(() => instantiateSpell.InstantiateLightning1()) },
            {"Lightning Spell2", new Action(() => instantiateSpell.InstantiateLightning2()) }
        };
    }

	public void TutorialRollDie()
	{
		int spellSlot = 0;
		for (int i = 0; i < 6; i++) 
		{
			if (currentSpellSlots[i] == "Fire Spell")
			{
				spellSlot = i;
			}
		}
		
	}

    
    //Li: i heavily crutched on ChatGPT for the methods below!! need to learn what they ACTUALLY do lol
    public void OnFaceChoiceClicked(int slotIndex)
	{
    	if(isInTutorial)
		{
			TutorialOnFaceChoiceClicked(slotIndex);
		}
  	 	else if (HasBeenClicked)
      		return;
		else
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
	}

void AssignSlotCastAction(int slotIndex, Action spellCastAction)
{
    switch (slotIndex)
    {
        case 0:
            instantiateSpell.SlotOneCast = spellCastAction;
            break;
        case 1:
            instantiateSpell.SlotTwoCast = spellCastAction;
            break;
        case 2:
            instantiateSpell.SlotThreeCast = spellCastAction;
            break;
        case 3:
            instantiateSpell.SlotFourCast = spellCastAction;
            break;
        case 4:
            instantiateSpell.SlotFiveCast = spellCastAction;
            break;
        case 5:
            instantiateSpell.SlotSixCast = spellCastAction;
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

	public void TutorialHideDiceFaceChoiceMenu()
    {
        CanvasGroupDisplayer.Hide(DiceFaceChoiceMenuPanel);
        powerUpChoiceMenu.ResumeGameAfterAllChoices();
		hasSelectedSpell=true;
    }

    private void StartHideDiceFaceChoiceMenu()
    { 
        CanvasGroupDisplayer.Hide(DiceFaceChoiceMenuPanel);
    }

    IEnumerator MenuSelectDelay()
    {
        HasBeenClicked = true;
        yield return new WaitForSeconds(1);
        HideDiceFaceChoiceMenu();
        
        SFXManager.Play("Boon");
        HasBeenClicked = false;
    }

	public void TutorialOnFaceChoiceClicked(int slotIndex)
	{
    
    	if (HasBeenClicked)
    	    return;
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
		/*
		for (int i = 0; i < diceFaceImages.length; i++)	
		{
			diceFaceImages[i].sprite = selectedSprite;
		}
		*/

    // Update the diceRoller DieRollSprites array with the correct sprite for the selected slot
	    //diceRoller.DieRollSprites[slotIndex] = selectedSprite;
		for (int i = 0; i < 6; i++)	
		{
			diceRoller.DieRollSprites[i] = selectedSprite;
		}

    // Set the corresponding spell casting action for the correct slot
	    //AssignSlotCastAction(slotIndex, spellCastAction);
		for (int i = 0; i < 6; i++)
		{
			AssignSlotCastAction(i, spellCastAction);
		}

    // Update the current spell slot for the selected index
	    //currentSpellSlots[slotIndex] = spellToBeApplied;
		for (int i = 0; i < 6; i++)
		{
			currentSpellSlots[i] = spellToBeApplied;
		}

    // Delay and hide the menu after the selection
	    StartCoroutine(TutorialMenuSelectDelay());
    
	}

	IEnumerator TutorialMenuSelectDelay()
    {
        HasBeenClicked = true;
        yield return new WaitForSeconds(1);
        TutorialHideDiceFaceChoiceMenu();
        
        SFXManager.Play("Boon");
        HasBeenClicked = false;
    }

    
}
using UnityEngine;
using UnityEngine.UI;

public class PowerUpChoiceMenu : MonoBehaviour
{
    
    //make a dictionary that connects string to icon -> have this pull from DiceFace??
    //could i make this a child of DiceFaceChoiceMenu???
    //finished turning if statement into DisplayChoice method
    
    //can refine the if statement WAY more in the DisplayChoiceIcon method
    
    public GameObject Choice1Button;
    public GameObject Choice2Button;
    public GameObject DeclineChoiceButton;
    public CanvasGroup PowerUpChoiceMenuPanel;
    public Text choice1;
    public Text choice2;
    public Image Choice1Image;
    public Image Choice2Image;
    public string Choice1;
    public string Choice2;
    public PowerUpRandomizer powerUpRandomizer;
    public Player Gambit;
    public WaveManager waveManager;
    public DiceFaceChoiceMenu diceFaceChoiceMenu;

    public Sprite IconIceSpell;
    public Sprite IconFireSpell;
    public Sprite IconHealSpell;
    public Sprite IconLightningSpell;

    void Start()
    {
        StartHidePowerUpChoiceMenu();
    }

    public void OnChoice1ButtonClick()
    {
        SFXManager.Play("SelectEffect");
        diceFaceChoiceMenu.spellToBeApplied = Choice1;
        HidePowerUpChoiceMenu();
    }
    
    public  void OnChoice2ButtonClick()
    {
        SFXManager.Play("SelectEffect");
        diceFaceChoiceMenu.spellToBeApplied = Choice2;
        HidePowerUpChoiceMenu();
    }
    
    
    public  void OnDeclineChoiceButtonClick()
    {
        SFXManager.Play("SelectEffect");
        DeclineHidePowerUpChoiceMenu();
        waveManager.GenerateNewWave();
        waveManager.waveClearedSwitch = false;
    }

    public void PauseGameDuringAllChoices()
    {
        Gambit.currentMoveSpeed = 0;
        Gambit.canAttack = false;
        //cannot roll dice/ cast spell

    }

    public void ResumeGameAfterAllChoices()
    {
        Gambit.currentMoveSpeed = GameParameters.PlayerMoveSpeed;
        Gambit.canAttack = true;
        //can roll dice/ cast spell
    }

    public void HidePowerUpChoiceMenu()
    {
        //add delays?
        CanvasGroupDisplayer.Hide(PowerUpChoiceMenuPanel);
        //ResumeGameAfterAllChoices();
        diceFaceChoiceMenu.ShowDiceFaceChoiceMenu();
        //waveManager.GenerateNewWave();
        //waveManager.waveClearedSwitch = false;

    }

    public void DeclineHidePowerUpChoiceMenu()
    {
        CanvasGroupDisplayer.Hide(PowerUpChoiceMenuPanel);
        ResumeGameAfterAllChoices();
    }
    
    public void StartHidePowerUpChoiceMenu()
    {
        //add delays?
        print(GameParameters.PlayerMoveSpeed);
        CanvasGroupDisplayer.Hide(PowerUpChoiceMenuPanel);
        ResumeGameAfterAllChoices();

    }

    public void DisplayChosenChoiceIcon(string choiceNumber, Image choiceIcon)
    {
        if (choiceNumber == "Fire Spell")
        {
            choiceIcon.sprite = IconFireSpell;
        }
        else if (choiceNumber == "Ice Spell")
        {
            choiceIcon.sprite = IconIceSpell;
        }
        else if (choiceNumber == "Heal Spell")
        {
            choiceIcon.sprite = IconHealSpell;
        }
        else if (choiceNumber == "Lightning Spell")
        {
            choiceIcon.sprite = IconLightningSpell;
        }
        else
        {
            print("choice 1 spell doesn't exist");

        }
    }

    public void ShowPowerUpChoiceMenu()
    {
        //add delays?
        CanvasGroupDisplayer.Show(PowerUpChoiceMenuPanel);
        
        Choice1 = powerUpRandomizer.RandomPowerUp();
        DisplayChosenChoiceIcon(Choice1, Choice1Image);
        
        Choice2 = powerUpRandomizer.RandomPowerUp();
        DisplayChosenChoiceIcon(Choice2, Choice2Image);
        
      
        choice1.text = "Choice 1: " + Choice1;
        choice2.text = "Choice 2: " + Choice2;
        PauseGameDuringAllChoices();
    }
    
   
    
     
  
}

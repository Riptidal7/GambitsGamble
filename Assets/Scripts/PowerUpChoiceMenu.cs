using UnityEngine;
using UnityEngine.UI;

public class PowerUpChoiceMenu : MonoBehaviour
{
    
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

        HidePowerUpChoiceMenu();
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
        ResumeGameAfterAllChoices();
        diceFaceChoiceMenu.ShowDiceFaceChoiceMenu();
        //waveManager.GenerateNewWave();
        //waveManager.waveClearedSwitch = false;

    }
    
    public void StartHidePowerUpChoiceMenu()
    {
        //add delays?
        print(GameParameters.PlayerMoveSpeed);
        CanvasGroupDisplayer.Hide(PowerUpChoiceMenuPanel);
        ResumeGameAfterAllChoices();

    }
    
    public void ShowPowerUpChoiceMenu()
    {
        //add delays?
        CanvasGroupDisplayer.Show(PowerUpChoiceMenuPanel);
        Choice1 = powerUpRandomizer.RandomPowerUp();
        if (Choice1 == "Fire Spell")
        {
            Choice1Image.sprite = IconFireSpell;
        }
        else if (Choice1 == "Ice Spell")
        {
            Choice1Image.sprite = IconIceSpell;
        }
        else if (Choice1 == "Heal Spell")
        {
            Choice1Image.sprite = IconHealSpell;
        }
        else
        {
            print("choice 1 spell doesn't exist");
        }
        
        Choice2 = powerUpRandomizer.RandomPowerUp();
        if (Choice2 == "Fire Spell")
        {
            Choice2Image.sprite = IconFireSpell;
        }
        else if (Choice2 == "Ice Spell")
        {
            Choice2Image.sprite = IconIceSpell;
        }
        else if (Choice2 == "Heal Spell")
        {
            Choice2Image.sprite = IconHealSpell;
        }
        else
        {
            print("choice 1 spell doesn't exist");
        }
        choice1.text = "Choice 1: " + Choice1;
        choice2.text = "Choice 2: " + Choice2;
        PauseGameDuringAllChoices();
    }
    
   
    
     
  
}

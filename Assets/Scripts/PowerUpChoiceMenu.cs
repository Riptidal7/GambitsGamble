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
    public PowerUpRandomizer powerUpRandomizer;
    public Player Gambit;
    public WaveManager waveManager;

    void Start()
    {
        StartHidePowerUpChoiceMenu();
    }

    public  void OnChoice1ButtonClick()
    {
        
        HidePowerUpChoiceMenu();
    }
    
    public  void OnChoice2ButtonClick()
    {

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
        waveManager.GenerateNewWave();
        waveManager.waveClearedSwitch = false;

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
        choice1.text = "Choice 1: " + powerUpRandomizer.RandomPowerUp();
        choice2.text = "Choice 2: " + powerUpRandomizer.RandomPowerUp();
        PauseGameDuringAllChoices();
    }
    
   
    
     
  
}

using UnityEngine;

public class PowerUpChoiceMenu : MonoBehaviour
{
    
    public GameObject Choice1Button;
    public GameObject Choice2Button;
    public GameObject DeclineChoiceButton;
    public CanvasGroup PowerUpChoiceMenuPanel;
    public Player Gambit;

    void Start()
    {
        HidePowerUpChoiceMenu();
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
        
        //this method will have to extend into both menus and then resume after the second menu
        ResumeGameAfterAllChoices();
    }
    
    public void ShowPowerUpChoiceMenu()
    {
        //add delays?
        CanvasGroupDisplayer.Show(PowerUpChoiceMenuPanel);
        PauseGameDuringAllChoices();
    }
    
   
    
     
  
}

using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public CanvasGroup PauseMenuCanvasGroup;
    public Player Gambit;
    private bool isShowing = false;
    
    public void Awake()
    {
        HideCanvasGroup();
    }

    public void ToggleShowingMenu()
    {
        if (isShowing)
        {
            Hide();
            isShowing = false;
        }
        else
        {
            Show();
            isShowing = true;
        }
    }
    
    public void Show()
    {
        // show the menu
        PauseMenuCanvasGroup.alpha = 1;
        PauseMenuCanvasGroup.blocksRaycasts = true;
        PauseMenuCanvasGroup.interactable = true;
        
        // pause the game
        Gambit.currentMoveSpeed = 0;
        Gambit.canAttack = false;
        PauseController.Pause();
    }

    public void Hide()
    {
        // hide the menu
        HideCanvasGroup();

        // unpause the game
        Gambit.currentMoveSpeed = GameParameters.PlayerMoveSpeed;
        Gambit.canAttack = true;
        PauseController.UnPause();
    }

    private void HideCanvasGroup()
    {
        PauseMenuCanvasGroup.alpha = 0;
        PauseMenuCanvasGroup.blocksRaycasts = false;
        PauseMenuCanvasGroup.interactable = false;
    }
    
}

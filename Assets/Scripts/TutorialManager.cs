using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public int tutorialSequence;
    public Text tutorialText;
    public GameObject tutorialEnemy;
    public SFXManager sfxManager;
    public GameObject skipButton;
    public PowerUpChoiceMenu powerUpChoiceMenu;
    public DiceFaceChoiceMenu diceFaceChoiceMenu;
    
    public GameObject tutorialCompletePanel;
    public Button continueButton;

    private bool isWaiting;
    private bool hasPowerUpMenuBeenShown;
    public bool hasSelectedSpell;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diceFaceChoiceMenu.isInTutorial = true;
        tutorialSequence = 0;
        tutorialEnemy.SetActive(false);
        tutorialCompletePanel.SetActive(false);
        isWaiting = false;
        hasPowerUpMenuBeenShown = false;
        
        //RunTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        // tell player to move
        if (tutorialSequence == 0 && !isWaiting)
        {
            tutorialText.text = "Use WASD to move";
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D))
            {
                StartCoroutine(CountdownForPause());
            }
        }

        // tell player to attack (melee)
        if (tutorialSequence == 1 && !isWaiting)
        {
            tutorialText.text = "Press Space to attack";
            if (!tutorialEnemy.activeSelf)
            {
                tutorialEnemy.SetActive(true);
            }
            
            if (tutorialEnemy.GetComponent<TutorialEnemy>().CheckHasBeenHit())
            {
                StartCoroutine(CountdownForPause());
            }
            
        }

        // tell player to choose a spell
        if (tutorialSequence == 2 && !isWaiting)
        {
            tutorialText.text = "Choose a Spell";

            // having problems here :(
            if (!hasPowerUpMenuBeenShown && powerUpChoiceMenu != null)
            {
                powerUpChoiceMenu.ShowPowerUpChoiceMenu();
                hasPowerUpMenuBeenShown = true;
            }

            if (diceFaceChoiceMenu.hasSelectedSpell)
            {
                diceFaceChoiceMenu.isInTutorial = false;
                StartCoroutine(CountdownForPause());
            }
        }

        if (tutorialSequence == 3 && !isWaiting)
        {
            tutorialText.text = "Left click to roll die";
            if (Input.GetMouseButtonDown(0)) 
            {
                StartCoroutine(CountdownForPause());
            }
        }

        if (tutorialSequence == 4 && !isWaiting)
        {
            tutorialText.text = "Right click to cast spell";
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(CountdownForPause());
            }
        }

        if (tutorialSequence == 5 && !isWaiting)
        {
            tutorialText.text = "";
            tutorialCompletePanel.SetActive(true);
            skipButton.SetActive(false);
        }
        
    }

    public void OnSkipButtonClicked()
    {
        diceFaceChoiceMenu.isInTutorial = false;
        SceneManager.LoadScene("GameScene");
    }

    IEnumerator CountdownForPause()
    {
        isWaiting = true;
        SFXManager.Play("Success");
        if (tutorialSequence < 3)
        {
            yield return new WaitForSeconds(1f);
        }
        else
        {
            yield return new WaitForSeconds(2f);
        }
        
        tutorialSequence++;
        isWaiting = false;
    }
    
}

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

    private bool isWaiting;
    private bool hasPowerUpMenuBeenShown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialSequence = 0;
        tutorialEnemy.SetActive(false);
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
        }

        
        
    }

    public void OnSkipButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    IEnumerator CountdownForPause()
    {
        isWaiting = true;
        SFXManager.Play("Success");
        yield return new WaitForSeconds(1f);
        tutorialSequence++;
        isWaiting = false;
    }
    
}

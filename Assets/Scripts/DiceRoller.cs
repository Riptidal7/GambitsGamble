using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DiceRoller : MonoBehaviour
{
    public int DieValue = 0;
    public List<Sprite> DieRollSprites;
    public Image DieImage;
    public bool WaitingToRoll = false;
    public bool CanICast = false;
    public Player Gambit;

    public GameObject StillImage;
    public GameObject RollingDie;

    void Update()
    {
        
    }

    public void RollDie()
    {
        if (Gambit.canAttack)
        {
            if (!WaitingToRoll)
            {
                UpdateDieImage();
                StartCoroutine(WaitTimerToRollAgain());
                CanICast = true;
            }
            else
            {
                print("waiting");
            }
        }
    }

    public int RandomSound()
    {
        int audioVersion = Random.Range(0, 2);
        return audioVersion;
    }
    
    public void RandomDieValue()
    {
        DieValue = Random.Range(0, DieRollSprites.Count);
    }

    public void UpdateDieImage()
    {
        RandomDieValue();
        DieImage.sprite = DieRollSprites[DieValue];
    }
    

    IEnumerator WaitTimerToRollAgain()
    {
        WaitingToRoll = true;
        //run animation
        StillImage.SetActive(false);
        RollingDie.SetActive(true);

        if (RandomSound() == 0)
        {
            SFXManager.Play("DiceRolling1");
        }
        else if (RandomSound() == 1)
        {
            SFXManager.Play("DiceRolling2");
        }
        else
        {
            SFXManager.Play("DiceRolling1");
        }
        
        yield return new WaitForSeconds(GameParameters.DiceRollWaitTime);
        //stop animation
        StillImage.SetActive(true);
        RollingDie.SetActive(false);
        WaitingToRoll = false;
    }
}

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

    public GameObject StillImage;
    public GameObject RollingDie;

    void Update()
    {
        
    }

    public void RollDie()
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
        yield return new WaitForSeconds(GameParameters.DiceRollWaitTime);
        //stop animation
        StillImage.SetActive(true);
        RollingDie.SetActive(false);
        WaitingToRoll = false;
    }
}

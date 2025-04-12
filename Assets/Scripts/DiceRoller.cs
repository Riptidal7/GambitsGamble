using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour
{
    public int DieValue = 0;
    public Text DieRollResult;
    public List<Sprite> DieRollSprites;

    public void UpdateDieText()
    {
        DieRollResult.text = DieValue.ToString();
    }
    
    public int RollDie()
    {
        RandomDieValue();
        return DieValue;
    }
    
    public void RandomDieValue()
    {
        DieValue = (int)Random.Range(GameParameters.DiceMinNumber, GameParameters.DiceMaxNumber);
    }
}

using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    public static int DieValue = 0;

    public static int RollDie()
    {
        RandomDieValue();
        return DieValue;
    }
    
    public static void RandomDieValue()
    {
        DieValue = (int)Random.Range(GameParameters.DiceMinNumber, GameParameters.DiceMaxNumber);
    }
}

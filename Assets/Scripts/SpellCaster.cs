using System.Collections;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public DiceRoller DiceRoller;
    public bool WaitingToCast = false;


    public void CastTheSpell(int SpellOnDie)
    {
        
    }
    public void CastAtSlotOnDie(int SpellOnDie)
    {
        if (SpellOnDie == 0)
        {
            print("I'm the boss, baby.");
        }
        if (SpellOnDie == 1)
        {
            print("CHICKEN JOCKEY");
        }
        if (SpellOnDie == 2)
        {
            print("I... AM STEVE");
        }
        if (SpellOnDie == 3)
        {
            print("Mrowr :3");
        }
        if (SpellOnDie == 4)
        {
            print("MARIA!!!!!!!");
        }
        if (SpellOnDie == 5)
        {
            print("Shimp");
        }
    }

    
    
}

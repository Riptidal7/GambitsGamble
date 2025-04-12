using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public DiceRoller DiceRoller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void CastAtSlot(int SpellOnDie)
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

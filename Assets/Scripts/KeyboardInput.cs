using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Player Gambit;
    public DiceRoller DiceRoller;
    public SpellCaster SpellCaster;
    public GameObject fireSpellPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Gambit.Move(new Vector2(0,1));
            //print("w");
        }
        if (Input.GetKey(KeyCode.S))
        {
            Gambit.Move(new Vector2(0,-1));
           // print("s");
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            Gambit.Move(new Vector2(-1,0));
           // print("a");
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            Gambit.Move(new Vector2(1,0));
         //   print("d");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Melee attack");
        }

        if (Input.GetMouseButtonDown(0))
        {
            DiceRoller.RollDie();
        }

        if (Input.GetMouseButtonDown(1))
        {
            SpellCaster.CastTheSpell(DiceRoller.DieValue);
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
          GameObject fireBall= Instantiate(fireSpellPrefab, Gambit.transform.position, Quaternion.identity);
          fireBall.transform.SetParent(Gambit.transform);
        }
    }
}

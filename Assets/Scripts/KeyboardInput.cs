using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Player Gambit;
    public DiceRoller DiceRoller;
    public SpellCaster SpellCaster;
    public MeleeAttackCooldownHandler meleeAttackCooldownHandler;
   
    
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
            Gambit.ChangeMovingStatus(true);
            //print("w");
        }
        if (Input.GetKey(KeyCode.S))
        {
            Gambit.Move(new Vector2(0,-1));
            Gambit.ChangeMovingStatus(true);
           // print("s");
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            Gambit.Move(new Vector2(-1,0));
            Gambit.ChangeDirection(DirectionType.Left);
            Gambit.ChangeMovingStatus(true);
            // print("a");
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            Gambit.Move(new Vector2(1,0));
            Gambit.ChangeDirection(DirectionType.Right);
            Gambit.ChangeMovingStatus(true);
            //   print("d");
        }

        if (!Input.GetKey(KeyCode.W) &&
            !Input.GetKey(KeyCode.A) &&
            !Input.GetKey(KeyCode.S) &&
            !Input.GetKey(KeyCode.D))
        {
            Gambit.ChangeMovingStatus(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            meleeAttackCooldownHandler.UseMeleeAttack();
        }

        if (Input.GetMouseButtonDown(0))
        {
            DiceRoller.RollDie();
        }

        if (Input.GetMouseButtonDown(1))
        {
            SpellCaster.CastTheSpell(DiceRoller.DieValue);
        }
        
    }
}

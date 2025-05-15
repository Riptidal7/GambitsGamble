using System.Collections;
using UnityEngine.Animations;
using UnityEngine;

public class MeleeAttackCooldownHandler : MonoBehaviour
{
    public GameObject meleeAttackPrefab;
    public GameObject meleeAttackLeftPrefab;
    public Player Gambit;
    public bool canUseMelee;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canUseMelee = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseMeleeAttack()
    {
        if(canUseMelee)

        {
            if (Gambit.direction == DirectionType.Right)
            {
                GameObject meleeAttack = Instantiate(meleeAttackPrefab,
                    new Vector3(Gambit.transform.position.x + 0.5f, Gambit.transform.position.y,
                        Gambit.transform.position.z),
                    Quaternion.identity);
                meleeAttack.transform.SetParent(Gambit.transform);
            }

            else if (Gambit.direction == DirectionType.Left)
            {
                GameObject meleeAttackLeft = Instantiate(meleeAttackLeftPrefab,
                    new Vector3(Gambit.transform.position.x - 0.5f, Gambit.transform.position.y,
                        Gambit.transform.position.z),
                    Quaternion.identity);
                meleeAttackLeft.transform.SetParent(Gambit.transform);
            }

            StartCoroutine(MeleeCooldown());
        }
    }

    IEnumerator MeleeCooldown()
    {
        canUseMelee = false;
        yield return new WaitForSeconds(GameParameters.MeleeCooldownSeconds);
        canUseMelee = true;
    }
}

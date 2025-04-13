using System.Collections;
using UnityEngine;

public class MeleeAttackCooldownHandler : MonoBehaviour
{
    public GameObject meleeAttackPrefab;
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
                GameObject meleeAttackPrefab = Instantiate(this.meleeAttackPrefab,
                    new Vector3(Gambit.transform.position.x + 0.5f, Gambit.transform.position.y,
                        Gambit.transform.position.z),
                    Quaternion.identity);
                meleeAttackPrefab.transform.SetParent(Gambit.transform);
            }

            else if (Gambit.direction == DirectionType.Left)
            {
                GameObject meleeAttackPrefab = Instantiate(this.meleeAttackPrefab,
                    new Vector3(Gambit.transform.position.x - 0.5f, Gambit.transform.position.y,
                        Gambit.transform.position.z),
                    Quaternion.identity);
                meleeAttackPrefab.transform.SetParent(Gambit.transform);
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

using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    void Start()
    {

        StartCoroutine(CountdownUntilDisappear());
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slime")
        {
            other.gameObject.GetComponent<Slime>().HitPoints -= GameParameters.MeleeAttackDamage;
         
        }
        
        if (other.gameObject.tag == "Mob2")
        {
            other.gameObject.GetComponent<Slime1>().HitPoints -= GameParameters.MeleeAttackDamage;
        }
    }

    IEnumerator CountdownUntilDisappear()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Destroy(gameObject);
    }
}

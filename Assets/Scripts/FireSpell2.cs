using System.Collections;
using UnityEngine;

public class FireSpell2 : MonoBehaviour
{
    public Health Health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        StartCoroutine(CountdownUntilDisappear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slime")
        {
            Slime slime = other.gameObject.GetComponent<Slime>();
            
     //       Health.TakeDamage(slime.HitPoints, GameParameters.FireSpell2FlatDamage);
            //other.gameObject.GetComponent<Slime>().HitPoints -= GameParameters.FireSpell2FlatDamage;
            slime.isBurning = true;
         
        }
        
        if (other.gameObject.tag == "Mob2")
        {
            Slime1 slime1 = other.gameObject.GetComponent<Slime1>();
            
        //    Health.TakeDamage(slime1.HitPoints, GameParameters.FireSpell2FlatDamage);
            //slime1.HitPoints -= GameParameters.FireSpell2FlatDamage;
            slime1.isBurning = true;
        }
        if (other.gameObject.tag == "RangedMob")
        {
            RangedMob rangedMob = other.gameObject.GetComponent<RangedMob>();
            
        //    Health.TakeDamage(rangedMob.HitPoints, GameParameters.FireSpell2FlatDamage);
            //rangedMob.HitPoints -= GameParameters.FireSpell2FlatDamage;
            rangedMob.isBurning = true;
        }
    }

    IEnumerator CountdownUntilDisappear()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}

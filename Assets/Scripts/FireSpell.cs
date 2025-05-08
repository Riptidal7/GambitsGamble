using System;
using System.Buffers.Text;
using System.Collections;
using UnityEngine;

public class FireSpell : SpellParent
{
    //NOTE BURNING DOES NOT EFFECT STRONGER PUPRLE MOB YET
    void Start()
    {
        SpellFlatDamage = GameParameters.FireSpell1DFlatDamage;
        
        base.Start();

    }

    void Update()
    {
        if  (hasCollided)
        {
            enemy.isBurning = true;
        }
    }
    
    

}
   























    //==============================================================
    // everything below is commented and added to SpellParent class 
    //==============================================================


    /* void Start()
     {

         StartCoroutine(CountdownUntilDisappear());
     }





     public void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.tag == "Slime")
         {
             other.gameObject.GetComponent<Slime>().HitPoints -= GameParameters.FireSpell1DFlatDamage;
             other.gameObject.GetComponent<Slime>().isBurning = true;

         }

         if (other.gameObject.tag == "Mob2")
         {
             other.gameObject.GetComponent<Slime1>().HitPoints -= GameParameters.FireSpell1DFlatDamage;
             other.gameObject.GetComponent<Slime1>().isBurning = true;
         }
     }

     IEnumerator CountdownUntilDisappear()
     {
         yield return new WaitForSeconds(1);
         GameObject.Destroy(gameObject);
     }
     */


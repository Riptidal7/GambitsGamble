using System.Collections;
using UnityEngine;

public class IceSpell : SpellParent
{
    void Start()
    {
        SpellFlatDamage = GameParameters.IceSpell1FlatDamage;
        
        base.Start();
    }
    
    void Update()
    {
        if (hasCollided)
        {
            enemy.isSlowed = true;
        }
    }
} 
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //==============================================================
    // everything below is commented and added to SpellParent class 
    //==============================================================
    
    /*void Start()
    {

        StartCoroutine(CountdownUntilDisappear());
    }


    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slime")
        {
            other.gameObject.GetComponent<Slime>().HitPoints-=GameParameters.IceSpell1FlatDamage;
            other.gameObject.GetComponent<Slime>().isSlowed = true;

        }

        if (other.gameObject.tag == "Mob2")
        {
            other.gameObject.GetComponent<Slime1>().HitPoints -=GameParameters.IceSpell1FlatDamage;
            other.gameObject.GetComponent<Slime1>().isSlowed = true;
        }
    }

    IEnumerator CountdownUntilDisappear()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    } */


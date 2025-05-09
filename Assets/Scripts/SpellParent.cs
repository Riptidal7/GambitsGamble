using System;
using System.Collections;
using UnityEngine;

public class SpellParent : MonoBehaviour
{
    public Enemy enemy;
        
    [NonSerialized]
    public int SpellFlatDamage;
    public bool hasCollided;
    
    protected void Start()
    {

        StartCoroutine(CountdownUntilDisappear());
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slime") 
        {
            hasCollided = true;
            enemy = other.gameObject.GetComponent<Slime>();
            
            enemy.HitPoints -= SpellFlatDamage;
         
        }
        
        if (other.gameObject.tag == "Mob2")
        {
            hasCollided = true;
            other.gameObject.GetComponent<Slime1>().HitPoints -= SpellFlatDamage;
        }
    }

    IEnumerator CountdownUntilDisappear()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        hasCollided = false;
    }
}

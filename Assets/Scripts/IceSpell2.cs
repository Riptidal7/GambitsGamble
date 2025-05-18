using System.Collections;
using UnityEngine;

public class IceSpell2 : MonoBehaviour
{
    public Health Health;
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
            
       //     Health.TakeDamage(slime.HitPoints, GameParameters.IceSpell2FlatDamage);
            //slime.HitPoints-=GameParameters.IceSpell2FlatDamage;
            slime.isFrozen = true;
         
        }
        
        if (other.gameObject.tag == "Mob2")
        {
            
            Slime1 slime1 = other.gameObject.GetComponent<Slime1>();
            
        //    Health.TakeDamage(slime1.HitPoints, GameParameters.IceSpell2FlatDamage);
            //other.gameObject.GetComponent<Slime1>().HitPoints -=GameParameters.IceSpell2FlatDamage;
            slime1.isFrozen = true;
        }
        if (other.gameObject.tag == "RangedMob")
        {
            RangedMob rangedMob = other.gameObject.GetComponent<RangedMob>();
            
      //      Health.TakeDamage(rangedMob.HitPoints, GameParameters.IceSpell2FlatDamage);
            //rangedMob.HitPoints -=GameParameters.IceSpell2FlatDamage;
            rangedMob.isFrozen = true;
        }
    }

    IEnumerator CountdownUntilDisappear()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class IceSpell2 : MonoBehaviour
{
    [FormerlySerializedAs("Health")] public DamageHandler damageHandler;
    void Start()
    {
        GetComponent<DamageHandler>();
        
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
            
            damageHandler.DisplayDamageNumber(GameParameters.IceSpell2FlatDamage, other.gameObject);
            slime.HitPoints-=GameParameters.IceSpell2FlatDamage;

            slime.isFrozen = true;
         
        }
        
        if (other.gameObject.tag == "Mob2")
        {
            
            Slime1 slime1 = other.gameObject.GetComponent<Slime1>();
            
            damageHandler.DisplayDamageNumber(GameParameters.IceSpell2FlatDamage, other.gameObject);
            other.gameObject.GetComponent<Slime1>().HitPoints -=GameParameters.IceSpell2FlatDamage;

            slime1.isFrozen = true;
        }
        if (other.gameObject.tag == "RangedMob")
        {
            RangedMob rangedMob = other.gameObject.GetComponent<RangedMob>();
            
            damageHandler.DisplayDamageNumber(GameParameters.IceSpell2FlatDamage, other.gameObject);
            rangedMob.HitPoints -=GameParameters.IceSpell2FlatDamage;

            rangedMob.isFrozen = true;
        }
    }

    IEnumerator CountdownUntilDisappear()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}

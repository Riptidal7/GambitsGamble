using System.Collections;
using UnityEngine;

public class IceSpell2 : MonoBehaviour
{
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
            other.gameObject.GetComponent<Slime>().HitPoints-=GameParameters.IceSpell2FlatDamage;
            other.gameObject.GetComponent<Slime>().isFrozen = true;
         
        }
        
        if (other.gameObject.tag == "Mob2")
        {
            other.gameObject.GetComponent<Slime1>().HitPoints -=GameParameters.IceSpell2FlatDamage;
            other.gameObject.GetComponent<Slime1>().isFrozen = true;
        }
        if (other.gameObject.tag == "RangedMob")
        {
            other.gameObject.GetComponent<RangedMob>().HitPoints -=GameParameters.IceSpell2FlatDamage;
            other.gameObject.GetComponent<RangedMob>().isFrozen = true;
        }
    }

    IEnumerator CountdownUntilDisappear()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}

using System.Collections;
using UnityEngine;

public class FireSpell2 : MonoBehaviour
{
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
            other.gameObject.GetComponent<Slime>().HitPoints -= GameParameters.FireSpell2FlatDamage;
            other.gameObject.GetComponent<Slime>().isBurning = true;
         
        }
        
        if (other.gameObject.tag == "Mob2")
        {
            other.gameObject.GetComponent<Slime1>().HitPoints -= GameParameters.FireSpell2FlatDamage;
            other.gameObject.GetComponent<Slime1>().isBurning = true;
        }
        if (other.gameObject.tag == "RangedMob")
        {
            other.gameObject.GetComponent<RangedMob>().HitPoints -= GameParameters.FireSpell2FlatDamage;
            other.gameObject.GetComponent<RangedMob>().isBurning = true;
        }
    }

    IEnumerator CountdownUntilDisappear()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}

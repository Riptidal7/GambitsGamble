using System.Collections;
using UnityEngine;

public class IceSpell : MonoBehaviour
{// Start is called once before the first execution of Update after the MonoBehaviour is created
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
    }
}

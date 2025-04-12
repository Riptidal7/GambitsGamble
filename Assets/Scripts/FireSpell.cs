using System;
using System.Collections;
using UnityEngine;

public class FireSpell : MonoBehaviour
{
    public string Name;
    public bool canActivate;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canActivate = true;
        StartCoroutine(CountdownUntilDisappear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slime" && canActivate)
        {
            //other.gameObject.GetComponent<Slime>().HitPoints -=5;
            other.gameObject.GetComponent<Slime>().isBurning = true;
            canActivate = false;
        }
        
        if (other.gameObject.tag == "Mob2" && canActivate)
        {
           // other.gameObject.GetComponent<Slime1>().HitPoints -=5;
            other.gameObject.GetComponent<Slime1>().isBurning = true;
            canActivate = false;
        }
    }

    IEnumerator CountdownUntilDisappear()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}

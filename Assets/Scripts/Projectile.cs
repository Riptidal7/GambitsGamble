using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projectileBody;
    private Player Gambit;
    void Start()
    {
        projectileBody = gameObject.GetComponent<Rigidbody2D>();
        Gambit = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Vector2 direction=new Vector2(Gambit.transform.position.x,Gambit.transform.position.y); ///I think direction issue is here
        float ProjectileStrength = 50f; //game parameters
        StartCoroutine(CountdownToDestroy());
        projectileBody.AddForce(direction*ProjectileStrength);
    }
    
    
    
    IEnumerator CountdownToDestroy()
    {
        yield return new WaitForSeconds(5f); //rename in game parameters as ProjectileLifespan
        Destroy(gameObject);
    }
    
    
}

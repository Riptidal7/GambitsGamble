using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projectileBody;
    private Player Gambit;
    bool hasBeenHitWithProjectile;
    void Start()
    {
       
       
        projectileBody = gameObject.GetComponent<Rigidbody2D>();
        Gambit = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Vector3 directionToPlayer = (Gambit.transform.position - transform.position).normalized;
        //Vector2 direction=new Vector2(Gambit.transform.position.x,Gambit.transform.position.y); ///I think direction issue is here
        float ProjectileSpeed = 350f; //game parameters
        StartCoroutine(CountdownToDestroy());
        projectileBody.AddForce(directionToPlayer*ProjectileSpeed);
    }
    
    
    
    IEnumerator CountdownToDestroy()
    {
        yield return new WaitForSeconds(5f); //rename in game parameters as ProjectileLifespan
        Destroy(gameObject);
    }
    
    
   public void OnTriggerEnter2D(Collider2D collider)
   {   
        
       DestroyProjectileOnPlayer(collider);
       
    }

    public void DestroyProjectileOnPlayer(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }

    
    
    
}

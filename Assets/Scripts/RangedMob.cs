using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RangedMob : Enemy
{
    private float minDistanceFromGambit = 250;
    public GameObject projectilePrefab;

    private bool canInstantiateProjectile = true;

    private bool isShooting = false; //to track if the mob is alr shooting a projectle
    
    private void Start()
    {
        enemySpeed = GameParameters.SlimeSpeed;
        currentEnemySpeed = enemySpeed;
        detectionRadius = GameParameters.SlimeDetectionRadius;
        minSecondsUntilFreeze = GameParameters.MinSecondsUntilSlimeFreeze;
        maxSecondsUntilFreeze = GameParameters.MaxSecondsUntilSlimeFreeze;
        HitPoints = GameParameters.SlimeHP;
        minSecondsUntilNextBurn = GameParameters.MinSecondsBeforeNextSlimeBurn;
        maxSecondsUntilNextBurn = GameParameters.MaxSecondsBeforeNextSlimeBurn;
        burnDuration = GameParameters.SlimeBurnDuration;
        defaultColor = GameParameters.defaultSlimeColor;
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
        slowDuration = GameParameters.SlimeSlowDuration;
        freezeDuration = GameParameters.SlimeFreezeDuration;
    }
  
    void Update()
    {
    
        if(canInstantiateProjectile && !isShooting)
        {
            print("mob is shooting bc it is close enough");
            print("slow poke is trying to stop to shoot projectile");
            StopMovingAndShootProjectile();
        }
        
        
    }

    private void StopMovingAndShootProjectile()
    {
        //prevents repeated more shooting if  already shooting
        if (isShooting) return;
        
        print("enemy should stop moving entirely");
        currentEnemySpeed = 0;
        
        isShooting = true;
        
        //starts delays within to make projectile shots feel good and timed
        StartCoroutine(DelayAndShootProjectile());

    }

    private void InstantiateProjectile()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    IEnumerator CooldownToInstantiateProjectile()
    {
        canInstantiateProjectile = false;
        yield return new WaitForSeconds(8f); //put into game parameters
        canInstantiateProjectile = true;
    }

    private IEnumerator DelayAndShootProjectile()
    {
        yield return new WaitForSeconds(2f); //put into game parameters: delayTimeBeforeShooting
        
        InstantiateProjectile();
        
        yield return new WaitForSeconds(2f); //put into game paramenters: delayTimeAfterShooting

        currentEnemySpeed = enemySpeed;
        StartCoroutine(CooldownToInstantiateProjectile());

        isShooting = false; //everything finished and can restart
    }
}

using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RangedMob : Enemy
{
    private float minDistanceFromGambit = GameParameters.MinDistanceFromGambit;  // unused, might use later if mobs retreat
    private float maxDistanceToMoveToGambit = GameParameters.MaxDistanceToMoveToGambit; // Maximum distance the mob is allowed to be from the player before it starts moving
    private float minShootDistance = GameParameters.MinShootDistance;
    private float maxShootDistance = GameParameters.MaxShootDistance;

    private float shootTolerance = GameParameters.ShootTolerance; // buffer zone to avoid mob flickering between two positons

    public GameObject projectilePrefab;
    
    private bool canInstantiateProjectile = true;
    private bool isShooting = false; //to track if the mob is alr shooting a projectle
    private bool shouldMove = true;  //  to track whether the mob should move
    
    
    
    private Transform playerTransform;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
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
  
    protected override void FixedUpdate()
    {
        //ensuring inherited code is called (all the potential spell effects inflicted, or death
        base.FixedUpdate();
        
        // Distance calculation to the player
        float distanceToGambit = Vector2.Distance(transform.position, playerTransform.position);
        print($"Distance to Gambit: {distanceToGambit}");
        
        //for readability of checks
        bool isTooFarToShoot = distanceToGambit > maxDistanceToMoveToGambit && !isShooting;
        bool isWithinShootRange = distanceToGambit >= minShootDistance - shootTolerance 
                                  && distanceToGambit <= maxShootDistance + shootTolerance 
                                  && canInstantiateProjectile 
                                  && !isShooting;
        bool isFarEnoughToMoveButNotShoot = distanceToGambit > maxShootDistance + shootTolerance 
                                      && distanceToGambit <= maxDistanceToMoveToGambit;

        // Allow movement if not shooting (inherited movement)
        if (isTooFarToShoot)
        {
            shouldMove = true;
            print($"shouldMove set to true. Distance: {distanceToGambit}");
        }
        else if (isWithinShootRange)
        {
            shouldMove = false;
            print($"shouldMove set to false. Distance: {distanceToGambit}");
            StopMovingAndShootProjectile();
        }
        else if (isFarEnoughToMoveButNotShoot)
        {
            shouldMove = true;
            print($"shouldMove set to true. Distance: {distanceToGambit}");
        }
        else
        {
            print($"No action taken. Distance: {distanceToGambit}");
            StopMovingAndShootProjectile();
        }
    }

    
    //Li: this is being called in parent class's fixed update
    //Li: method is called in parent class, but you can use "override" to change the logic only in the child class 
    //Li: in this case im using a bool to dictate when i want to move the ranged mob (differently from slimes)
    public override void MoveTowardsPlayer()
    {
       
        if (shouldMove)
        {
            base.MoveTowardsPlayer();
        }
       
    }

    private void StopMovingAndShootProjectile()
    {
        //prevents repeated more shooting if  already shooting
        if (isShooting) return;
        
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
        yield return new WaitForSeconds(GameParameters.InstantiateProjectileCooldown); 
        canInstantiateProjectile = true;
    }

    private IEnumerator DelayAndShootProjectile()
    {
        yield return new WaitForSeconds(GameParameters.DelayTimeBeforeShooting); 
        
        InstantiateProjectile();
        
        yield return new WaitForSeconds(GameParameters.DelayTimeAfterShooting); 

        currentEnemySpeed = enemySpeed;
        StartCoroutine(CooldownToInstantiateProjectile());

        isShooting = false; //everything finished and can restart
    }
}

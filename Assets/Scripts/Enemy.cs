using System;
using System.Collections;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Transform player;    // Reference to the player's Transform component for tracking the player's position
    public float enemySpeed;     // Speed at which the enemy moves
    public float detectionRadius;    // Radius within which the enemy detects the player
    public bool isWaitingToFreezeRandomly;
    public float minSecondsUntilFreeze;
    public float maxSecondsUntilFreeze;
    public float currentEnemySpeed;
    public int HitPoints;
    public WaveManager waveManager;
    public bool isBurning;
    public bool canTakeBurnDamage;
    public float minSecondsUntilNextBurn;
    public float maxSecondsUntilNextBurn;
    public int burnDuration;
    public Color defaultColor;
    public bool isSlowed;
    public int slowDuration;
    public bool isFrozen;
    public int freezeDuration;
    public bool struckByLightning;
    

    public bool canKnockback;  
    public float knockbackCooldown;  
    
    private Rigidbody2D rb;

    public VisualEffect mobEffects;

    public DamageHandler damageHandler;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   // Initializes the Rigidbody component attached to the enemy
        player = GameObject.FindWithTag("Player").transform;
        
        damageHandler = GameObject.FindWithTag("Handler").GetComponent<DamageHandler>();
        waveManager = GameObject.FindWithTag("WaveManager").GetComponent<WaveManager>();
        isWaitingToFreezeRandomly = false;
        isBurning = false;
        canTakeBurnDamage = true;
    }
    
    protected virtual void FixedUpdate()
    {
        if (PauseController.IsPaused)
            return;
        if (!isWaitingToFreezeRandomly)
        {
            StartCoroutine(CountdownUntilFreezeRandomly());
        }
        
        //check for 0 hp happening in health class rn. might be able to delete.
        if (HitPoints <= 0)
        {
            Die();
        }

        if (isBurning)
        {
            if(canTakeBurnDamage)
            {
                damageHandler.DisplayDamageNumber(1, gameObject);
                HitPoints--;

                canTakeBurnDamage = false;
                StartCoroutine(CountdownUntilNextBurnDamage());
                StartCoroutine(CountdownUntilBurningOver());
            }
        }
        if (isSlowed)
        {
            StartCoroutine(CountdownUntilSlowOver());
        }

        if (isFrozen)
        {
            StartCoroutine(CountdownUntilFreezeOver());
        }

        if (struckByLightning)
        {
            StartCoroutine(CountdownForLightningStrike());
        }
        if (player != null && Vector3.Distance(player.position, transform.position) <= detectionRadius)
        {
            MoveTowardsPlayer();
            
        }
        
    }
    
    // Method to start knockback cooldown
    public void StartKnockbackCooldown()
    {
        if (!canKnockback) return;  // If already in cooldown, don't start again
        StartCoroutine(ResetKnockbackCooldown());
    }

    // Coroutine to reset the knockback flag after the cooldown
    private IEnumerator ResetKnockbackCooldown()
    {
        canKnockback = false;  
        yield return new WaitForSeconds(knockbackCooldown);  
        canKnockback = true;  
    }
    

    //"virtual" allows a method to be overridden in child classes
    public virtual void MoveTowardsPlayer()
    {
        // Calculate the normalized direction vector from the enemy to the player
        Vector3 direction = (player.position - transform.position).normalized;
        // Moves enemy towards player
        rb.MovePosition(transform.position + direction * currentEnemySpeed * Time.fixedDeltaTime);
    }
    
    IEnumerator CountdownUntilFreezeRandomly()
    {
        isWaitingToFreezeRandomly = true;
        yield return new WaitForSecondsWhileUnpaused(Random.Range(minSecondsUntilFreeze,maxSecondsUntilFreeze));
        currentEnemySpeed = 0;
        yield return new WaitForSecondsWhileUnpaused(1);
        currentEnemySpeed = enemySpeed;
        isWaitingToFreezeRandomly = false;
    }
    
    IEnumerator CountdownUntilBurningOver()
    {
		mobEffects.SendEvent("isBurning");
        yield return new WaitForSecondsWhileUnpaused(burnDuration);
        isBurning = false;
		mobEffects.SendEvent("stopBurning");
    }
    
    IEnumerator CountdownUntilSlowOver()
    {
        currentEnemySpeed = enemySpeed / 2;
		mobEffects.SendEvent("isSlow");
        yield return new WaitForSecondsWhileUnpaused(slowDuration);
        currentEnemySpeed = enemySpeed;
        isSlowed = false;
		mobEffects.SendEvent("stopSlow");
    }

    IEnumerator CountdownUntilFreezeOver()
    {
        currentEnemySpeed = 0;
		mobEffects.SendEvent("isFrozen");
        yield return new WaitForSecondsWhileUnpaused(freezeDuration);
        currentEnemySpeed = enemySpeed;
        isFrozen = false;
		mobEffects.SendEvent("stopFrozen");
    }

    IEnumerator CountdownForLightningStrike()
    {
        gameObject.GetComponent<SpriteRenderer>().color=Color.yellow;
        yield return new WaitForSeconds(1);
        struckByLightning = false;
    }

    IEnumerator CountdownUntilNextBurnDamage()
    {
        yield return new WaitForSecondsWhileUnpaused(Random.Range(minSecondsUntilNextBurn,maxSecondsUntilNextBurn));
        canTakeBurnDamage = true;
    }

    public void Die()
    {
        waveManager.CurrentWave.enemies.Remove(gameObject);

        Destroy(gameObject);
    }

}

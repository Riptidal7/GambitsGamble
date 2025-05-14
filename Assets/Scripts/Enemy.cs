using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

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
    
    private Rigidbody2D rb;

    public VisualEffect burningEffect;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   // Initializes the Rigidbody component attached to the enemy
        player = GameObject.FindWithTag("Player").transform;
        waveManager = GameObject.FindWithTag("WaveManager").GetComponent<WaveManager>();
        isWaitingToFreezeRandomly = false;
        isBurning = false;
        canTakeBurnDamage = true;
    }
    
    void FixedUpdate()
    {
        if (PauseController.IsPaused)
            return;
        
        if (player != null && Vector3.Distance(player.position, transform.position) <= detectionRadius)
        {
            // Calculate the normalized direction vector from the enemy to the player
            Vector3 direction = (player.position - transform.position).normalized;
            // Moves enemy towards player
            rb.MovePosition(transform.position + direction * currentEnemySpeed * Time.fixedDeltaTime);
        }

        if (!isWaitingToFreezeRandomly)
        {
            StartCoroutine(CountdownUntilFreezeRandomly());
        }

        if (HitPoints <= 0)
        {
            Die();
        }

        if (isBurning)
        {
            if(canTakeBurnDamage)
            {
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
        gameObject.GetComponent<SpriteRenderer>().color=Color.red;
		burningEffect.SendEvent("isBurning");
        yield return new WaitForSecondsWhileUnpaused(burnDuration);
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
        isBurning = false;
		burningEffect.SendEvent("stopBurning");
    }
    
    IEnumerator CountdownUntilSlowOver()
    {
        gameObject.GetComponent<SpriteRenderer>().color=Color.cyan;
        currentEnemySpeed = enemySpeed / 2;
        yield return new WaitForSecondsWhileUnpaused(slowDuration);
        currentEnemySpeed = enemySpeed;
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
        isSlowed= false;
    }

    IEnumerator CountdownUntilFreezeOver()
    {
        
        gameObject.GetComponent<SpriteRenderer>().color=Color.blue;
        currentEnemySpeed = 0;
        yield return new WaitForSecondsWhileUnpaused(freezeDuration);
        currentEnemySpeed = enemySpeed;
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
        isFrozen= false;
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

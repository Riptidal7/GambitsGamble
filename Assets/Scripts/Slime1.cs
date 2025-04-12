using System.Collections;
using UnityEngine;

public class Slime1 : MonoBehaviour
{
    public Transform player;    // Reference to the player's Transform component for tracking the player's position
    public float enemySpeed;     // Speed at which the enemy moves
    public float detectionRadius;    // Radius within which the enemy detects the player
    public bool isWaitingToFreezeRandomly;
    public Vector3 spawnLocation;
    
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // Initializes the Rigidbody component attached to the enemy
        enemySpeed = GameParameters.Mob2Speed;
        detectionRadius = GameParameters.Mob2DetectionRange;
        player = GameObject.FindWithTag("Player").transform;
        isWaitingToFreezeRandomly = false;
    }
    
    void FixedUpdate()
    {
        if (player != null && Vector3.Distance(player.position, transform.position) <= detectionRadius)
        {
            // Calculate the normalized direction vector from the enemy to the player
            Vector3 direction = (player.position - transform.position).normalized;
            // Moves enemy towards player
            rb.MovePosition(transform.position + direction * enemySpeed * Time.fixedDeltaTime);
        }

        if (!isWaitingToFreezeRandomly)
        {
            StartCoroutine(CountdownUntilFreezeRandomly());
        }
    }

    IEnumerator CountdownUntilFreezeRandomly()
    {
        isWaitingToFreezeRandomly = true;
        yield return new WaitForSeconds(Random.Range(GameParameters.MinSecondsUntilMob2Freeze,GameParameters.MaxSecondsUntilMob2Freeze));
        enemySpeed = 0;
        yield return new WaitForSeconds(1);
        enemySpeed = GameParameters.SlimeSpeed;
        isWaitingToFreezeRandomly = false;
    }
}

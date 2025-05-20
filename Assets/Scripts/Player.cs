using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    
    public SpriteRenderer GambitSpriteRenderer;
    public HPDisplayer HpDisplayer;
    public bool TakingDamageSlime;
    public bool TakingDamageMob2;
    public bool TakingDamageRangedMobProjectile;
    public bool CanTakeDamage;
    
    public int HitPoints;

    public float currentMoveSpeed;
    public bool canAttack;

	public DirectionType direction;
	public bool isMoving;
	public bool isMovingFront;
	public bool isMovingBack;
	public Animator animator;

	public DamageHandler damageHandler;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HitPoints = GameParameters.InitialMaxPlayerHitPoints;
        HpDisplayer.UpdateHP(HitPoints);
        TakingDamageSlime = false;
        CanTakeDamage = true;
		direction = DirectionType.Right;
		isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
	    if (CanTakeDamage)
	    {
		    // Check if the player is in contact with any damaging object
		    if (TakingDamageSlime)
		    {
			    TakeDamage(1); // Apply damage for Slime
		    }

		    if (TakingDamageMob2)
		    {
			    TakeDamage(2); // Apply damage for Mob2
		    }

		    if (TakingDamageRangedMobProjectile)
		    {
			    TakeDamage(1); // Apply damage for Ranged Mob Projectile
		    }
	    }
        
    }
    
    private void TakeDamage(int damage)
    {
	    
	    // Apply the damage and play sound
	    
	    //i think if the object is destroyed too fast, the damage numbers wont appear
	    damageHandler.DisplayDamageNumber(damage, gameObject);
	    HitPoints -= damage;

	    SFXManager.Play("PlayerTakesDamage");
	    HpDisplayer.UpdateHP(HitPoints);

	    // Check for game over
	    if (GameManager.CheckIfGameOver(gameObject.GetComponent<Player>()))
	    {
		    GameManager.LoadScene("GameOver");
	    }
	    // Start invulnerability period
	    CanTakeDamage = false; // Disable further damage application
	    StartCoroutine(CountdownUntilInvulnerabilityOver()); // Start the coroutine to reset invulnerability
	    
    }

    public void Move(Vector2 direction)
    {
        float xAmount = direction.x * currentMoveSpeed * Time.deltaTime;
        float yAmount = direction.y * currentMoveSpeed * Time.deltaTime;
        
        
        if (GambitSpriteRenderer.transform.position.x < GameParameters.MapMinX)
        {
            GambitSpriteRenderer.transform.Translate(GameParameters.PlayerConstraintKnockback,0,0);
        }
        else if (GambitSpriteRenderer.transform.position.x > GameParameters.MapMaxX)
        {
            GambitSpriteRenderer.transform.Translate(-GameParameters.PlayerConstraintKnockback,0,0);
        }
        else if (GambitSpriteRenderer.transform.position.y < GameParameters.MapMinY)
        {
            GambitSpriteRenderer.transform.Translate(0,GameParameters.PlayerConstraintKnockback,0);
        }
        else if (GambitSpriteRenderer.transform.position.y > GameParameters.MapMaxY)
        {
            GambitSpriteRenderer.transform.Translate(0,-GameParameters.PlayerConstraintKnockback,0);
        }
        else
        {
            GambitSpriteRenderer.transform.Translate(xAmount, yAmount, 0.0f);
        }
    }

	public void ChangeDirection(DirectionType newDirection) 
	{
		if (newDirection == DirectionType.Left)
		{
			direction = DirectionType.Left;
			animator.SetBool("facingLeft", true);
		}
		else if (newDirection == DirectionType.Right)
		{
			direction = DirectionType.Right;
			animator.SetBool("facingLeft", false);
		}
	}

	public void ChangeMovingStatus(bool isGambitMoving)
	{
		if (isGambitMoving)
		{
			isMoving = true;
			animator.SetBool("isMoving", true);
		}
		
		else 
		{
			isMoving = false;
			animator.SetBool("isMoving", false);
		}
	}

	public void ChangeMovingFront(bool isMovingFront)
	{
		this.isMovingFront = isMovingFront;
		animator.SetBool("isRunningFront", isMovingFront);
	}

	public void ChangeMovingDown(bool isMovingBack)
	{
		this.isMovingBack = isMovingBack;
		animator.SetBool("isRunningBack", isMovingBack);
	}
	
	//addin moving down

    public void OnTriggerEnter2D(Collider2D other)
    {
            if (other.CompareTag("Slime"))
            {
                TakingDamageSlime = true;
            }
            if (other.CompareTag("Mob2"))
            {
                TakingDamageMob2 = true;
            }
            if (other.CompareTag("EnemyProjectile"))
            {
	            TakingDamageRangedMobProjectile = true;
            }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
	    if (other.CompareTag("Slime"))
        {
            TakingDamageSlime = false;
        }
	    if (other.CompareTag("Mob2"))
        {
            TakingDamageMob2 = false;
        }
	    if (other.CompareTag("EnemyProjectile"))
        {
	        TakingDamageRangedMobProjectile = false;
        }
    }

	IEnumerator CountdownUntilInvulnerabilityOver()
	{
		// repetitive code, possible to fix?
		//animator.SetBool("isTakingDamage", true);
		GambitSpriteRenderer.color = Color.red;
		yield return new WaitForSeconds(GameParameters.SecondsOfDamageIndicator);
		
		//animator.SetBool("isTakingDamage", false);
		GambitSpriteRenderer.color = Color.white;
		yield return new WaitForSeconds(GameParameters.SecondsOfDamageIndicator);
		
		//animator.SetBool("isTakingDamage", true);
		GambitSpriteRenderer.color = Color.red;
		yield return new WaitForSeconds(GameParameters.SecondsOfDamageIndicator);

		animator.SetBool("isTakingDamage", false);
		GambitSpriteRenderer.color = Color.white;

		float timeSpentFlashingRed = GameParameters.SecondsOfDamageIndicator * 3;
		float timeLeftUntilInvulnerabilityOver = GameParameters.SecondsOfInvulnerabilityAfterDamage - timeSpentFlashingRed;
		
		yield return new WaitForSeconds(timeLeftUntilInvulnerabilityOver);
		CanTakeDamage = true;
		
		// Reset the damage flags after invulnerability
		TakingDamageSlime = false;
		TakingDamageMob2 = false;
		TakingDamageRangedMobProjectile = false;
		
	}

	// tried to fix repetition in CountdownUntilDamgeIndicatorDone
	// does not work
	IEnumerator SetRed()
	{
		animator.SetBool("isTakingDamage", true);
		yield return new WaitForSeconds(GameParameters.SecondsOfDamageIndicator);
		animator.SetBool("isTakingDamage", false);
	}

	IEnumerator SetNormal()
	{
		animator.SetBool("isTakingDamage", false);
		yield return new WaitForSeconds(GameParameters.SecondsOfDamageIndicator);
	}
}

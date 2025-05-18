using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
	GameObject damageNumberPrefab;
	public KnockbackFeedback knockbackFeedback;  // Only keep this one reference for KnockbackFeedback
	public Player Gambit;
	public Health Health;
	public GameObject damageTextPrefab;
    
	//public Color defaultColor;

    void Start()
    {
		// Ensure Gambit is properly assigned
	    Gambit = GameObject.FindWithTag("Player").GetComponent<Player>();
	    Health = GameObject.FindWithTag("Handler").GetComponent<Health>();
        StartCoroutine(CountdownUntilDisappear());
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
	    //intialize knockback variables to be changed in method later
	    DirectionType direction = Gambit.direction;
	    Vector2 knockbackDirection = Vector2.zero;

        SFXManager.Play("EnemyTakesMeleeDamage");

		if (other.gameObject.CompareTag("TutorialEnemy"))
		{
			TutorialEnemy tutorialEnemy = other.gameObject.GetComponent<TutorialEnemy>();
			SpriteRenderer spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
			Color defaultColor = Color.white;
			tutorialEnemy.SetHasBeenHit(true);
			StartCoroutine(CountdownForDamageIndicator(spriteRenderer, defaultColor));
		}

        if (other.gameObject.CompareTag("Slime"))
        {
	        Slime slime = other.gameObject.GetComponent<Slime>();

	       // Health.TakeDamage(slime.HitPoints, GameParameters.MeleeAttackDamage); //NEW CODE ADDED HERE
	        slime.HitPoints -= GameParameters.MeleeAttackDamage;
	        
	        Health.DisplayDamageNumber(GameParameters.MeleeAttackDamage, other.gameObject);
	        
	        if (!slime.canKnockback) //if slime can't knock back, stop here
		        return;
	        
	        KnockbackFeedback slimeKnockback = slime.GetComponent<KnockbackFeedback>();
	        if (slimeKnockback != null)
	        {
		        
		        slimeKnockback.AssignKnockbackDirection(direction, ref knockbackDirection);  // Pass by reference
		        slimeKnockback.ApplyKnockback(direction, knockbackDirection);
		    
	        }
	        
	        slime.StartKnockbackCooldown();
	       
			if (slime.HitPoints > 0)
			{
				SpriteRenderer spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
				Color defaultColor = slime.defaultColor;
				
				StartCoroutine(CountdownForDamageIndicator(spriteRenderer, defaultColor));
			}
			
        }
        
        if (other.gameObject.CompareTag("Mob2"))
        {	
	        Slime1 slime1 = other.gameObject.GetComponent<Slime1>();
	        
	      //  Health.TakeDamage(slime1.HitPoints, GameParameters.MeleeAttackDamage); //NEW CODE HERE 
	        //slime1.HitPoints -= GameParameters.MeleeAttackDamage;
	        
	        if (!slime1.canKnockback) //if slime1/mob2 can't knock back, stop here
		        return;

	        // Get KnockbackFeedback component from the Slime1
	        KnockbackFeedback slime1Knockback = slime1.GetComponent<KnockbackFeedback>();
	        if (slime1Knockback != null)
	        {
		        slime1Knockback.AssignKnockbackDirection(direction, ref knockbackDirection);  // Pass by reference
		        slime1Knockback.ApplyKnockback(direction, knockbackDirection);
	        }
	        
	        slime1.StartKnockbackCooldown();
	        
			if (slime1.HitPoints > 0)
			{
				SpriteRenderer spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
				Color defaultColor = slime1.defaultColor;
				StartCoroutine(CountdownForDamageIndicator(spriteRenderer, defaultColor));
			}
			
		}
        
        if (other.gameObject.CompareTag("RangedMob"))
        {	
	        RangedMob rangedMob = other.gameObject.GetComponent<RangedMob>();
	        
	    //    Health.TakeDamage(rangedMob.HitPoints, GameParameters.MeleeAttackDamage);
	        //rangedMob.HitPoints -= GameParameters.MeleeAttackDamage;
	        
	        if (!rangedMob.canKnockback) //if rangedMob can't knock back, stop here
		        return;

	        // Get KnockbackFeedback component from the Slime1
	        KnockbackFeedback rangedMobKnockback = rangedMob.GetComponent<KnockbackFeedback>();
	        if (rangedMobKnockback != null)
	        {
		        rangedMobKnockback.AssignKnockbackDirection(direction, ref knockbackDirection);  // Pass by reference
		        rangedMobKnockback.ApplyKnockback(direction, knockbackDirection);
	        }
	        
	        rangedMob.StartKnockbackCooldown();
	        
	        if (rangedMob.HitPoints > 0)
	        {
		        SpriteRenderer spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
		        Color defaultColor = rangedMob.defaultColor;
		        StartCoroutine(CountdownForDamageIndicator(spriteRenderer, defaultColor));
	        }
			
        }
    }

    IEnumerator CountdownUntilDisappear()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Destroy(gameObject);
    }

	IEnumerator CountdownForDamageIndicator(SpriteRenderer spriteRenderer, Color defaultColor) 
	{
		spriteRenderer.color=Color.red;
		yield return new WaitForSeconds(GameParameters.SecondsOfDamageIndicator);

		spriteRenderer.color=defaultColor;
		yield return new WaitForSeconds(GameParameters.SecondsOfDamageIndicator);

		spriteRenderer.color=Color.red;
		yield return new WaitForSeconds(GameParameters.SecondsOfDamageIndicator);

		spriteRenderer.color=defaultColor;

		if (spriteRenderer.color != defaultColor)
		{
			spriteRenderer.color = defaultColor;
		}
	}
}

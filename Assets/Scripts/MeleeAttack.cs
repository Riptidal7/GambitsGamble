using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
	public KnockbackFeedback knockbackFeedback;  // Only keep this one reference for KnockbackFeedback
	public Player Gambit;
    
	//public Color defaultColor;

    void Start()
    {
		// Ensure Gambit is properly assigned
	    Gambit = GameObject.FindWithTag("Player").GetComponent<Player>();

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
	        slime.HitPoints -= GameParameters.MeleeAttackDamage;
	        
	        KnockbackFeedback slimeKnockback = slime.GetComponent<KnockbackFeedback>();
	        if (slimeKnockback != null)
	        {
		        slimeKnockback.AssignKnockbackDirection(direction, ref knockbackDirection);  // Pass by reference
		        Debug.Log("Applying knockback to Slime in direction: " + knockbackDirection);
		        slimeKnockback.ApplyKnockback(direction, knockbackDirection);
	        }
	        else
		        Debug.LogWarning("No KnockbackFeedback component found on the Slime!");


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
	        slime1.HitPoints -= GameParameters.MeleeAttackDamage;

	        // Get KnockbackFeedback component from the Slime1
	        KnockbackFeedback slime1Knockback = slime1.GetComponent<KnockbackFeedback>();
	        if (slime1Knockback != null)
	        {
		        slime1Knockback.AssignKnockbackDirection(direction, ref knockbackDirection);  // Pass by reference
		        Debug.Log("Applying knockback to Slime1 in direction: " + knockbackDirection);
		        slime1Knockback.ApplyKnockback(direction, knockbackDirection);
	        }
	        else
		        Debug.LogWarning("No KnockbackFeedback component found on the Slime1!");
	        
			if (slime1.HitPoints > 0)
			{
				SpriteRenderer spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
				Color defaultColor = slime1.defaultColor;
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

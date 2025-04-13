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
    public bool CanTakeDamage;
    
    
    public int HitPoints;

    public float currentMoveSpeed;
    public bool canAttack;

	public DirectionType direction;
	public Animator animator;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HitPoints = GameParameters.InitialMaxPlayerHitPoints;
        HpDisplayer.UpdateHP(HitPoints);
        TakingDamageSlime = false;
        CanTakeDamage = true;
		direction = DirectionType.Right;
    }

    // Update is called once per frame
    void Update()
    {
        if (TakingDamageSlime)
        {
            if (CanTakeDamage)
            {
                HitPoints--;
                if (Game.CheckIfGameOver(gameObject.GetComponent<Player>()))
                {
                    Game.ChangeSceneToGameOver();
                }
                HpDisplayer.UpdateHP(HitPoints);
                CanTakeDamage = false;
                StartCoroutine(CountdownUntilInvulnerabilityOver());
            }
        }
        
        if (TakingDamageMob2)
        {
            if (CanTakeDamage)
            {
                HitPoints-=2;
                if (Game.CheckIfGameOver(gameObject.GetComponent<Player>()))
                {
                    Game.ChangeSceneToGameOver();
                }
                HpDisplayer.UpdateHP(HitPoints);
                CanTakeDamage = false;
                StartCoroutine(CountdownUntilInvulnerabilityOver());
            }
        }
        
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

    public void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.tag == "Slime")
            {
                TakingDamageSlime = true;
            }
            if (other.gameObject.tag == "Mob2")
            {
                TakingDamageMob2 = true;
            }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Slime")
        {
            TakingDamageSlime = false;
        }
        if (other.gameObject.tag == "Mob2")
        {
            TakingDamageMob2 = false;
        }
    }

    IEnumerator CountdownUntilInvulnerabilityOver()
    {
        yield return new WaitForSeconds(GameParameters.SecondsOfInvulnerabilityAfterDamage);
        CanTakeDamage = true;
    }
}

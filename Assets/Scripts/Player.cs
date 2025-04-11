using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer GambitSpriteRenderer;
    public HPDisplayer HpDisplayer;
    public bool TakingDamage;
    public bool CanTakeDamage;
    
    public int HitPoints;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HitPoints = GameParameters.InitialMaxPlayerHitPoints;
        HpDisplayer.UpdateHP(HitPoints);
        TakingDamage = false;
        CanTakeDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TakingDamage)
        {
            if (CanTakeDamage)
            {
                HitPoints--;
                HpDisplayer.UpdateHP(HitPoints);
                CanTakeDamage = false;
                StartCoroutine(CountdownUntilInvulnerabilityOver());
            }
        }
        
    }

    public void Move(Vector2 direction)
    {
        float xAmount = direction.x * GameParameters.PlayerMoveSpeed;
        float yAmount = direction.y * GameParameters.PlayerMoveSpeed;
        
        
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

    public void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.tag == "Enemy")
            {
                TakingDamage = true;
            }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakingDamage = false;
        }
    }

    IEnumerator CountdownUntilInvulnerabilityOver()
    {
        yield return new WaitForSeconds(GameParameters.SecondsOfInvulnerabilityAfterDamage);
        CanTakeDamage = true;
    }
}

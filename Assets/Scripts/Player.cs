using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer GambitSpriteRenderer;
    public HPDisplayer HpDisplayer;
    public bool TakingDamage;
    public int FPSCheck;
    public int HitPoints;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HitPoints = GameParameters.InitialMaxPlayerHitPoints;
        HpDisplayer.UpdateHP(HitPoints);
        TakingDamage = false;
        FPSCheck = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (TakingDamage)
        {
            if(FPSCheck==120)
            {
                HitPoints--;
                HpDisplayer.UpdateHP(HitPoints);
                FPSCheck = 0;
            }

            FPSCheck++;
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
            FPSCheck = 120;
        }
    }
}

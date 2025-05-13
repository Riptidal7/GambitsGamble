using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    
	//public Color defaultColor;

    void Start()
    {

        StartCoroutine(CountdownUntilDisappear());
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        SFXManager.Play("EnemyTakesMeleeDamage");
        if (other.gameObject.tag == "Slime")
        {
			other.gameObject.GetComponent<Slime>().HitPoints -= GameParameters.MeleeAttackDamage;

			if (other.gameObject.GetComponent<Slime>().HitPoints > 0)
			{
				SpriteRenderer spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
				Color defaultColor = other.gameObject.GetComponent<Slime>().defaultColor;
				StartCoroutine(CountdownForDamageIndicator(spriteRenderer, defaultColor));
			}
			
        }
        
        if (other.gameObject.tag == "Mob2")
        {	
			other.gameObject.GetComponent<Slime1>().HitPoints -= GameParameters.MeleeAttackDamage;

			if (other.gameObject.GetComponent<Slime>().HitPoints > 0)
			{
				SpriteRenderer spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
				Color defaultColor = other.gameObject.GetComponent<Slime1>().defaultColor;
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

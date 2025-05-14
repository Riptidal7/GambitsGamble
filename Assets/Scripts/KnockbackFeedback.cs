using System;
using System.Collections;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using Vector2 = UnityEngine.Vector2;


public class KnockbackFeedback : MonoBehaviour
{


  
   [SerializeField]
   private Rigidbody2D rb2d;


   private float strength = 5000f;
   [SerializeField] private float delay = 0.15f;


   public UnityEvent OnBegin, OnDone;
  


   public Vector2 ReturnKnockbackDirection(DirectionType directionType)
   {
       switch (directionType)
       {
           case DirectionType.Left:
               return new Vector2 (-1, 0);
                    
           case DirectionType.Right:
               return new Vector2 (1, 0);
           default:
               Debug.Log("Unknown direction so returning as 0,0" );
               return new Vector2(0, 0);
       }
   }
  
   public void AssignKnockbackDirection(DirectionType directionType, ref Vector2 direction)
   {
       // change direction of knockback to opposite direction of where the player's facing
       switch (directionType)
       {
           case DirectionType.Left:
               direction = -transform.right;
               break;
                    
           case DirectionType.Right:
               direction = transform.right;
               break;
           default:
               Debug.Log("Unknown direction " + direction);
               break;
       }
   }


 
   public void ApplyKnockback(DirectionType directionType, Vector2 direction)
   {
       // Ensure the Rigidbody2D is present on the enemy object
       if (rb2d == null)
       {
           Debug.LogError("Rigidbody2D is missing on " + gameObject.name);
           return;
       }


       // Normalize the direction to ensure the knockback is consistent
       Vector2 knockbackDirection = direction.normalized;
      
       Debug.Log("Applying Knockback - Direction: " + knockbackDirection + ", Strength: " + strength);


       // Apply an impulse force to the Rigidbody2D in the opposite direction of the player's movement
       //rb2d.linearVelocity = knockbackDirection *strength;
       rb2d.AddForce(knockbackDirection * strength);
      // rb2d.linearDamping = 3f;
      
       OnBegin?.Invoke(); // Optionally trigger a UnityEvent for visual effects or other events


       // Optional: Stop the enemy after a short delay to prevent them from being pushed too far
       StartCoroutine(Reset());
   }


   private IEnumerator Reset()
   {
       // Wait for a short duration to allow the knockback force to be applied
       yield return new WaitForSeconds(delay);


       // Optionally reset velocity or any other properties (like movement speed) after knockback
       rb2d.linearVelocity = Vector2.zero; // Zero out velocity to stop unwanted movement after knockback


       OnDone?.Invoke();
   }
}


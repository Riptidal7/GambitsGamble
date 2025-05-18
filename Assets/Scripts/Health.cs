using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    //public DamageNumber damageNumber;
    
    public GameObject damageTextPrefab;  // 3D TextMeshPro prefab for damage numbers
    public Vector3 damageNumberOffset = new Vector3(0, 1f, 0);  // Offset for the damage number position
    public float randomOffsetRangeX = 0.2f;  // Horizontal range for random offset
    public float randomOffsetRangeY = 0.5f;  // Vertical range for random offset

    public void TakeDamage(int hitpoints, int damageAmount, GameObject enemy)
    {
        hitpoints -= damageAmount;
        DisplayDamageNumber(damageAmount, enemy);

        if (hitpoints <= 0)
        {
            Die();
        }
    }

    public void DisplayDamageNumber(int damageAmount, GameObject objectTakingDamage)
    {
        // Calculate random offsets for the position
        float randomX = Random.Range(-randomOffsetRangeX, randomOffsetRangeX);
        float randomY = Random.Range(-randomOffsetRangeY, randomOffsetRangeY);

        // Calculate the spawn position in world space, above the mob
        Vector3 spawnPosition = objectTakingDamage.transform.position;

        // Instantiate the damage text prefab at the calculated position
        Instantiate(damageTextPrefab, spawnPosition, Quaternion.identity);


        //Set text to the damage amount
        print(damageTextPrefab.ToString());
        damageTextPrefab.GetComponent<DamageNumber>().Setup(damageAmount);
    }

        

    // Display the damage number above the enemy with a random position
    /*private void DisplayDamageNumber(int damageAmount)
    {
        // Generate random offsets within range
        float randomX = Random.Range(-randomOffsetRangeX, randomOffsetRangeX);
        float randomY = Random.Range(-randomOffsetRangeY, randomOffsetRangeY);

        // Calculate the random spawn based on the mob position
        Vector3 randomOffset = new Vector3(randomX, randomY, 0);
        Vector3 spawnPosition = transform.position + damageNumberOffset + randomOffset;

        // Instantiate the damage number prefab at the calculated position
        GameObject damageNumber = Instantiate(damageNumberPrefab, spawnPosition, Quaternion.identity);

        // Find the Canvas and parent the damage number to it
        Canvas canvas = FindObjectOfType<Canvas>();  // Find the first Canvas in the scene
        if (canvas != null)
        {
            // Parent the damage number to the canvas
            damageNumber.transform.SetParent(canvas.transform, false);  // 'false' keeps world position
        }
        else
        {
            Debug.LogError("No Canvas found in the scene!");
        }


        Debug.Log("Damage number instantiated at position: " + damageNumber.transform.position);

        // set text to the damage amount
        damageNumber.GetComponent<DamageNumber>().Setup(damageAmount);
    }*/

    // Handle death
    private void Die()
    {

        Destroy(gameObject);
    }
}

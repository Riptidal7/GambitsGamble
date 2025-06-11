using TMPro;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    //public DamageNumber damageNumber;
    
    public GameObject damageTextPrefab;  // 3D TextMeshPro prefab for damage numbers
    public Vector3 damageNumberOffset = new Vector3(0, 1f, 0);  // Offset for the damage number position
    public float randomOffsetRangeX = 0.2f;  // Horizontal range for random offset
    public float randomOffsetRangeY = 0.5f;  // Vertical range for random offset

    
    //want to use this later down the line
    public void TakeDamage(int hitpoints, int damageAmount, GameObject enemy)
    {
        hitpoints -= damageAmount;
        DisplayDamageNumber(damageAmount, enemy);

        if (hitpoints <= 0)
        {
           // Die();
        }
    }

    public void DisplayDamageNumber(int damageAmount, GameObject objectTakingDamage)
    {
       
        // Calculate random offsets for the position
        float randomX = Random.Range(-randomOffsetRangeX, randomOffsetRangeX);
        float randomY = Random.Range(-randomOffsetRangeY, randomOffsetRangeY);

        // Calculate the spawn position in world space, above the mob
        Vector3 spawnPosition = objectTakingDamage.transform.position;

        // Instantiate the damage text prefab at the calculated position and store the instance
        GameObject instance = Instantiate(damageTextPrefab, spawnPosition, Quaternion.identity);
        
        // Get the TMP_Text and set color based on tag
        TMP_Text tmp = instance.GetComponent<TMP_Text>();
        if (tmp != null)
        {
            tmp.color = objectTakingDamage.CompareTag("Player") ? Color.white : Color.red;
        }
        
        // Set the damage amount on the instance
        DamageNumber damageNumber = instance.GetComponent<DamageNumber>();
        if (damageNumber != null)
        {
            damageNumber.Setup(damageAmount);
        }
        else
        {
            Debug.LogError("DamageNumber component missing on damageTextPrefab!");
        }
    }
    
}

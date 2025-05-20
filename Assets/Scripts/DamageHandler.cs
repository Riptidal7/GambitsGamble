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

        // Instantiate the damage text prefab at the calculated position
        Instantiate(damageTextPrefab, spawnPosition, Quaternion.identity);


        //Set text to the damage amount
        print(damageTextPrefab.ToString());
        damageTextPrefab.GetComponent<DamageNumber>().Setup(damageAmount);
    }
    
}

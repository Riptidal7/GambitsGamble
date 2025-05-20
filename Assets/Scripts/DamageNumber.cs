using System.Collections;
using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    public float moveSpeed = 1f;  // Speed at which the damage number moves upwards
    public float fadeDuration = 1f;  // Duration for the number to fade out
    public TMP_Text damageText;  // Reference to the TMP_Text component

    void Start()
    {
        
        // Try to find the TMP_Text component in the children (if it's not on the same GameObject)
        damageText = GetComponent<TMP_Text>();  
        damageText.fontSize = 10;
       // damageText.color = Color.red;
        StartCoroutine(MoveAndFade());
        if (damageText == null)
        {
            Debug.LogError("DamageNumber prefab is missing a TMP_Text component!");
        }
    }

    public void Setup(int damageAmount)
    {
        if (damageText != null)
        {
            // Set the damage amount as text
            damageText.text ="-" + damageAmount.ToString();

            // Start the movement and fade effect
          //  gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("damageText is null! Please check that TMP_Text is assigned correctly.");
        }
    }

    public IEnumerator MoveAndFade()
    {
        print("coroutine started");
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Move the damage number upwards
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            // Fade the text (by changing its alpha)
            Color currentColor = damageText.color;
            currentColor.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            damageText.color = currentColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Destroy the GameObject after fading out
        Destroy(gameObject);
    }
}
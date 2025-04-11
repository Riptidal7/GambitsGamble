using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplayer : MonoBehaviour
{
    public Text HPText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHP(int HP)
    {
        HPText.text = "HP: " + HP;
    }
}

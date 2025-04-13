using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplayer : MonoBehaviour
{
    public Text HPText;
    

    public void UpdateHP(int HP)
    {
        HPText.text = "HP: " + HP;
    }
}

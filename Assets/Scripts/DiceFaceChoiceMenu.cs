using JetBrains.Annotations;
using UnityEngine;


public class DiceFaceChoiceMenu : MonoBehaviour
{
    GameObject DiceFaceChoice1;
    GameObject DiceFaceChoice2;
    GameObject DiceFaceChoice3;
    GameObject DiceFaceChoice4;
    GameObject DiceFaceChoice5;
    GameObject DiceFaceChoice6;
 
    public CanvasGroup DiceFaceChoiceMenuPanel;




    void Start()
    {
        HideDiceFaceChoiceMenu();
    }
 
    public void ShowDiceFaceChoiceMenu()
    {
        CanvasGroupDisplayer.Show(DiceFaceChoiceMenuPanel);
    }
    public void HideDiceFaceChoiceMenu()
    {
        CanvasGroupDisplayer.Hide(DiceFaceChoiceMenuPanel);
    }


 
    public void OnFaceChoice1Clicked()
    {
        HideDiceFaceChoiceMenu();
    }
 
    public void OnFaceChoice2Clicked()
    {
        HideDiceFaceChoiceMenu();
    }
 
    public void OnFaceChoice3Clicked()
    {
        HideDiceFaceChoiceMenu();
    }
 
    public void OnFaceChoice4Clicked()
    {
        HideDiceFaceChoiceMenu();
    }
 
    public void OnFaceChoice5Clicked()
    {
        HideDiceFaceChoiceMenu();
    }
 
    public void OnFaceChoice6Clicked()
    {
        HideDiceFaceChoiceMenu();
    }
}
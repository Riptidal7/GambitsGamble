using UnityEngine;

public class WaveClearDisplayer : MonoBehaviour
{
    public CanvasGroup WaveClearPanel;
   
    void Start()
    {
        HideWaveClearPanel();
    }

    public void ShowWaveClearPanel()
    {
        CanvasGroupDisplayer.Show(WaveClearPanel);
    }

    public void HideWaveClearPanel()
    {
        CanvasGroupDisplayer.Hide(WaveClearPanel);
    }
}

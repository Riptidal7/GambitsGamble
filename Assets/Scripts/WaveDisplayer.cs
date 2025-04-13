using UnityEngine;
using UnityEngine.UI;

public class WaveDisplayer : MonoBehaviour
{
    public Text WaveText;
    

    public void UpdateWaveCount(int WaveCount)
    {
        WaveText.text = "Wave: " + WaveCount;
    }
}

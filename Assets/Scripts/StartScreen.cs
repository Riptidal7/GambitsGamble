using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{

    public GameObject StartButton;

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

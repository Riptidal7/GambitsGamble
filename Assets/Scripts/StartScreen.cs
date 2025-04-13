using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{

    public GameObject StartButton;
    public GameObject BackgroundMusic;

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}

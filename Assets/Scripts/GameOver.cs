using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject quitButton;
    public GameObject retryButton
        ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void OnRetryButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void OnQuitButtonClick()
    {
       Application.Quit();
       Debug.Log("game is exitting");
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

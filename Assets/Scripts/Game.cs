using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Game
{
    
    public static void Play()
    {
        SceneManager.LoadScene("StartMenu");
    }
    
    public static void ChangeSceneToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public static bool CheckIfGameOver(Player player)
    {
        if (player.HitPoints <= 0)
            return true;
        
        return false;
    }
    
}

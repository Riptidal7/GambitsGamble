using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public static void Play()
	{
		SceneManager.LoadScene("StartMenu");
	}

	public static void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public static void ReloadCurrentScene()
	{
		Scene currentScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(currentScene.name);
	}

	public static void LoadNextScene()
	{
		int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
		if (nextIndex < SceneManager.sceneCountInBuildSettings)
		{
			SceneManager.LoadScene(nextIndex);
		}
		else
		{
			Debug.LogWarning("No next scene to load.");
		}
	}

	public static bool CheckIfGameOver(Player player)
	{
		if (player.HitPoints <= 0)
			return true;
		return false;
	}

}

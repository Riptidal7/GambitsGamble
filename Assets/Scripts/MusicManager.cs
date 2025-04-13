using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;

    void Start()
    {
        musicSource.Play();
    }
    
}

using UnityEngine;
using System.Collections.Generic;

public class SFXManager : MonoBehaviour
{
    public static AudioSource sfxSource;
    public static SFXManager instance;

    [System.Serializable]
    public struct NamedSFX
    {
        public string name;
        public AudioClip clip;
    }
    
    public NamedSFX[] soundEffects;
    
    private static Dictionary<string, AudioClip> sfxDict;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            sfxSource = GetComponent<AudioSource>();
            sfxDict = new Dictionary<string, AudioClip>();
            foreach (NamedSFX s in soundEffects)
            {
                sfxDict[s.name] = s.clip;
            }        
        }
        
    }

    public static void Play(string sfxName)
    {
        if (sfxDict == null || sfxSource == null)
        {
            Debug.LogWarning("SFXManager not initialized");
            return;
        }
        
        if (sfxDict.ContainsKey(sfxName))
        {
            sfxSource.PlayOneShot(sfxDict[sfxName]);
        }

        else
        {
            Debug.LogWarning("SFX " + sfxName + " not found");
        }
    }
}

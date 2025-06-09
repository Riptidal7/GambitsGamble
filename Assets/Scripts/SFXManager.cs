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
        public float cooldown;
    }
    
    public NamedSFX[] soundEffects;
    
    private static Dictionary<string, AudioClip> sfxDict;
    private static Dictionary<string, float> sfxCooldownDict;
    private static Dictionary<string, float> lastPlayTimeDict;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            sfxSource = GetComponent<AudioSource>();
            sfxDict = new Dictionary<string, AudioClip>();
            sfxCooldownDict = new Dictionary<string, float>();
            lastPlayTimeDict = new Dictionary<string, float>();
            foreach (NamedSFX s in soundEffects)
            {
                sfxDict[s.name] = s.clip;
                sfxCooldownDict[s.name] = s.cooldown;
                lastPlayTimeDict[s.name] = -Mathf.Infinity;
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
            float lastPlayed = lastPlayTimeDict[sfxName];
            float cooldown = sfxCooldownDict[sfxName];

            if (Time.time >= lastPlayed + cooldown)
            {
                sfxSource.PlayOneShot(sfxDict[sfxName]);
                lastPlayTimeDict[sfxName] = Time.time;
            }
        }

        else
        {
            Debug.LogWarning("SFX " + sfxName + " not found");
        }
    }
}

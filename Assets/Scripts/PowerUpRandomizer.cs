using System.Collections.Generic;
using UnityEngine;

public class PowerUpRandomizer : MonoBehaviour
{
    
    public List<GameObject> powerUps;

    public GameObject fireSpellPrefab;

    public GameObject iceSpellPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerUps.Add(fireSpellPrefab);
        powerUps.Add(iceSpellPrefab);
    }

    public GameObject RandomPowerUp()
    {
        int randIndex = Random.Range(0, powerUps.Count);
        return powerUps[randIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

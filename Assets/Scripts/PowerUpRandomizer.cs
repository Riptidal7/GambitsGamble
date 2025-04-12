using System.Collections.Generic;
using UnityEngine;

public class PowerUpRandomizer : MonoBehaviour
{
    
    public List<string> powerUps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerUps.Add("ice");
        powerUps.Add("fire");
        powerUps.Add("heal");
    }

    public string RandomPowerUp()
    {
        int randIndex = Random.Range(0, powerUps.Count);
        return powerUps[randIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyWave : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int NumberOfSlimes;
    public int NumberOfMob2s;
    public GameObject SlimePrefab;
    public GameObject Mob2Prefab;

    public void CreateNewWave(int numberOfSlimes, int numberOfMob2s)
    {
        NumberOfSlimes = numberOfSlimes;
        NumberOfMob2s = numberOfMob2s;
        for (int a = 0; a < NumberOfSlimes;a++)
        {
            Vector3 SlimeSpawnLocation = new Vector3(Random.Range(GameParameters.MapMinX, GameParameters.MapMaxX),
                Random.Range(GameParameters.MapMinY, GameParameters.MapMaxY), 0);
            Instantiate(SlimePrefab, SlimeSpawnLocation, Quaternion.identity);
        } 
        for (int a = 0; a < numberOfMob2s;a++)
        {
           Vector3 Mob2SpawnLocation = new Vector3(Random.Range(GameParameters.MapMinX, GameParameters.MapMaxX),
               Random.Range(GameParameters.MapMinY, GameParameters.MapMaxY), 0);
           Instantiate(Mob2Prefab, Mob2SpawnLocation, Quaternion.identity);
           NumberOfMob2s++;
        }
    }
    
    // Update is called once per frame

    public bool IsWaveCleared()
    {
        if (NumberOfMob2s== 0 && NumberOfMob2s== 0)
        {
            return true;
        }

        return false;
    }
}

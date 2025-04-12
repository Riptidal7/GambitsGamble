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
    public List<GameObject> enemies;
    public GameObject Mob2Prefab;

    public void CreateNewWave(int numberOfSlimes, int numberOfMob2s)
    {
        NumberOfSlimes = numberOfSlimes;
        NumberOfMob2s = numberOfMob2s;
        for (int a = 0; a < NumberOfSlimes;a++)
        {
            Vector3 SlimeSpawnLocation = new Vector3(Random.Range(GameParameters.MapMinX, GameParameters.MapMaxX),
                Random.Range(GameParameters.MapMinY, GameParameters.MapMaxY), 0);
            GameObject tempSlime=Instantiate(SlimePrefab, SlimeSpawnLocation, Quaternion.identity);
            enemies.Add(tempSlime);
        } 
        for (int a = 0; a < NumberOfMob2s;a++)
        {
           Vector3 Mob2SpawnLocation = new Vector3(Random.Range(GameParameters.MapMinX, GameParameters.MapMaxX),
               Random.Range(GameParameters.MapMinY, GameParameters.MapMaxY), 0);
           GameObject tempMob2=Instantiate(Mob2Prefab, Mob2SpawnLocation, Quaternion.identity);
           enemies.Add(tempMob2);
        }
    }
    
    // Update is called once per frame

    public bool IsWaveCleared()
    {
        if (enemies.Count==0)
        {
            return true;
        }

        return false;
    }
}

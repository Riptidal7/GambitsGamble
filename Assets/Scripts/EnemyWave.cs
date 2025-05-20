using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyWave : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int NumberOfSlimes;
    public int NumberOfMob2s;
    public int NumberofRangedMobs; //will def need this
    public GameObject SlimePrefab;
    public List<GameObject> ColoredSlimePrefabs;
    public List<GameObject> enemies;
    public GameObject Mob2Prefab;
    public Player Gambit;
    public bool WaveCleared;

    public GameObject RangedMobPrefab;
    
    public void CreateNewWave(int numberOfSlimes, int numberOfMob2s, int numberofRangedMobs)
    {
        NumberOfSlimes = numberOfSlimes;
        NumberOfMob2s = numberOfMob2s;
        NumberofRangedMobs = numberofRangedMobs;
        for (int a = 0; a < NumberOfSlimes;a++)
        {
            Vector3 SlimeSpawnLocation = new Vector3(Random.Range(GameParameters.MapMinX, GameParameters.MapMaxX),
                Random.Range(GameParameters.MapMinY, GameParameters.MapMaxY), 0);
            while (Vector3.Distance(SlimeSpawnLocation,Gambit.transform.position)<5)
            {
                SlimeSpawnLocation = new Vector3(Random.Range(GameParameters.MapMinX, GameParameters.MapMaxX),
                    Random.Range(GameParameters.MapMinY, GameParameters.MapMaxY), 0);
            }
            int randomColoredSlimeIndex = Random.Range(0, ColoredSlimePrefabs.Count);
            GameObject tempSlime=Instantiate(ColoredSlimePrefabs[randomColoredSlimeIndex], SlimeSpawnLocation, Quaternion.identity);
            enemies.Add(tempSlime);
        } 
        for (int a = 0; a < NumberOfMob2s;a++)
        {
           Vector3 Mob2SpawnLocation = new Vector3(Random.Range(GameParameters.MapMinX, GameParameters.MapMaxX),
               Random.Range(GameParameters.MapMinY, GameParameters.MapMaxY), 0);
           while (Vector3.Distance(Mob2SpawnLocation,Gambit.transform.position)<5)
           {
               Mob2SpawnLocation = new Vector3(Random.Range(GameParameters.MapMinX, GameParameters.MapMaxX),
                   Random.Range(GameParameters.MapMinY, GameParameters.MapMaxY), 0);
           }
           GameObject tempMob2=Instantiate(Mob2Prefab, Mob2SpawnLocation, Quaternion.identity);
           enemies.Add(tempMob2);
        }
        for (int a = 0; a < NumberofRangedMobs;a++)
        {
            Vector3 RangedMobSpawnLocation = new Vector3(Random.Range(GameParameters.MapMinX, GameParameters.MapMaxX),
                Random.Range(GameParameters.MapMinY, GameParameters.MapMaxY), 0);
            while (Vector3.Distance(RangedMobSpawnLocation,Gambit.transform.position)<5)
            {
                RangedMobSpawnLocation = new Vector3(Random.Range(GameParameters.MapMinX, GameParameters.MapMaxX),
                    Random.Range(GameParameters.MapMinY, GameParameters.MapMaxY), 0);
            }
            GameObject tempRangedMob = Instantiate(RangedMobPrefab, RangedMobSpawnLocation, Quaternion.identity);
            enemies.Add(tempRangedMob);
        }
    }
    
    // Update is called once per frame

    public bool IsWaveCleared()
    {
        if (enemies.Count==0)
        {
            WaveCleared = true;
            return WaveCleared;
        }

        WaveCleared = false;
        return WaveCleared;
    }
}

using UnityEngine;

public  class WaveManager : MonoBehaviour
{
    public  int waveNumber=1;
    public bool AddMob2s=true;
    public int MaxEnemies;
    public EnemyWave CurrentWave = new EnemyWave();

    void Start()
    {
        GenerateNewWave();
    }
    public void GenerateNewWave()
    {
        int numbSlimes = Random.Range(GameParameters.MinNumberSlimesPerWave, GameParameters.MaxNumberSlimesPerWave+1) + waveNumber;
        int numbMob2s = 0;
        if(AddMob2s)
        {
            numbMob2s = Random.Range(GameParameters.MinNumberMob2sPerWave, GameParameters.MaxNumberMob2sPerWave+1) + waveNumber-1;
            AddMob2s = false;
        }
        else
        {
            AddMob2s = true;
        }
        CurrentWave.CreateNewWave(numbSlimes,numbMob2s);
        waveNumber++;
    }
}

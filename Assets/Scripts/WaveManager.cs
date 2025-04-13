using System;
using UnityEngine;
using Random = UnityEngine.Random;

public  class WaveManager : MonoBehaviour
{
    public  int waveNumber;
    public bool AddMob2s;
    public int MaxEnemies;
    public EnemyWave CurrentWave = new EnemyWave();
    public PowerUpChoiceMenu powerUpChoiceMenu;

    public bool waveClearedSwitch;

    void Start()
    {
        waveNumber = 1;
        AddMob2s = false;
        waveClearedSwitch = false;
        GenerateNewWave();
    }
    public void GenerateNewWave()
    {
        print("new wave");
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
            numbMob2s = waveNumber - 1;
        }
        CurrentWave.CreateNewWave(numbSlimes,numbMob2s);
        waveNumber++;
    }

    private void Update()
    {
        if (CurrentWave.IsWaveCleared() && !waveClearedSwitch)
        {
            print("cleared");
            waveClearedSwitch = true;
            powerUpChoiceMenu.ShowPowerUpChoiceMenu();
            //GenerateNewWave();
        }
    }
}

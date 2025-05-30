using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public  class WaveManager : MonoBehaviour
{
    public  int waveNumber;
    //public bool AddMob2s;
    public int MaxEnemies;
    public EnemyWave CurrentWave = new EnemyWave();
    public PowerUpChoiceMenu powerUpChoiceMenu;
    public WaveDisplayer WaveDisplayer;

    public bool waveClearedSwitch;
    
    public SFXManager sfxManager;
    public WaveClearDisplayer waveClearDisplayer;

    void Start()
    {
		if (SceneManager.GetActiveScene().name == "TutorialScene")
		{
			waveNumber = 0;
			waveClearedSwitch = false;
		}
		else
		{
        waveNumber = 1;
        //AddMob2s = false;
        waveClearedSwitch = false;
        GenerateNewWave();
		}
    }
    public void GenerateNewWave()
    {
        WaveDisplayer.UpdateWaveCount(waveNumber);
        int numbSlimes = Random.Range(GameParameters.MinNumberSlimesPerWave, GameParameters.MaxNumberSlimesPerWave+1)/2 + waveNumber;
        int numbMob2s = 0;
        int numbRangedMobs = 0; 
            //
        if (waveNumber >= 2)
        {
            numbRangedMobs = Random.Range(GameParameters.MinNumberRangedMobsPerWave, GameParameters.MaxNumberRangedMobsPerWave)/2 + waveNumber;  
        }
        if(waveNumber % 3 == 0)
        {
            numbMob2s = waveNumber/3;
            //AddMob2s = false;
        }
        else
        {
            //AddMob2s = true;
            //numbMob2s = waveNumber - 1;
        }
        CurrentWave.CreateNewWave(numbSlimes,numbMob2s, numbRangedMobs);
        waveNumber++;
    }

    private void Update()
    {
        if (CurrentWave.IsWaveCleared() && !waveClearedSwitch && waveNumber > 0)
        {
            StartCoroutine(ClearWave());
           // waveClearedSwitch = true;
           // powerUpChoiceMenu.ShowPowerUpChoiceMenu();
            //GenerateNewWave();
        }
    }

    IEnumerator ClearWave()
    {
        waveClearedSwitch = true;
        //PLAY WAVE CLEAR SOUND
        waveClearDisplayer.ShowWaveClearPanel();
        SFXManager.Play("Success");
        yield return new WaitForSeconds(2);
        waveClearDisplayer.HideWaveClearPanel();
        powerUpChoiceMenu.ShowPowerUpChoiceMenu();
        //GenerateNewWave();
    }
}

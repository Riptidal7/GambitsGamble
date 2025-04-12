using UnityEngine;

public static class GameParameters
{
    //Charlotte: I'm pretty sure knockback has to be greater than movespeed or he'll vibrate forward anyway
    public static float PlayerMoveSpeed = 0.04f;
    public static float PlayerConstraintKnockback = 0.05f;

    public static int InitialMaxPlayerHitPoints = 5;

    public static int SecondsOfInvulnerabilityAfterDamage = 1;

    public static float SlimeSpeed = 1.5f;
    public static float SlimeDetectionRadius=100;

    public static float Mob2Speed = 3;
    public static float Mob2DetectionRange = 100;

    public static int SlimeHP = 5;

    public static int Mob2HP = 5;

    public static int SlimeBurnDuration = 15;
    public static int Mob2BurnDuration = 15;

    public static float MinSecondsBeforeNextSlimeBurn = 1;
    public static float MaxSecondsBeforeNextSlimeBurn = 3;
    
    public static float MinSecondsBeforeNextMob2Burn = 1;
    public static float MaxSecondsBeforeNextMob2Burn = 3;

    public static int MinNumberSlimesPerWave = 1;
    public static int MaxNumberSlimesPerWave = 2;

    public static int MinNumberMob2sPerWave = 0;
    public static int MaxNumberMob2sPerWave = 1;

    public static float MinSecondsUntilSlimeFreeze = 3;
    public static float MaxSecondsUntilSlimeFreeze = 7;

    public static float MinSecondsUntilMob2Freeze = 5;
    public static float MaxSecondsUntilMob2Freeze = 10;

    public static float MapMinX = -10;
    public static float MapMaxX = 10;

    public static float MapMinY = -10;
    public static float MapMaxY = 10;
}

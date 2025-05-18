using UnityEngine;

public static class GameParameters
{
    //Charlotte: I'm pretty sure knockback has to be greater than movespeed or he'll vibrate forward anyway
    public static float PlayerMoveSpeed = 5f;
    public static float PlayerConstraintKnockback = 0.05f;

    public static int InitialMaxPlayerHitPoints = 50;

    public static float MeleeCooldownSeconds = 1;

    public static int SecondsOfInvulnerabilityAfterDamage = 1;
    public static float SecondsOfDamageIndicator = 0.1f;

    public static float SlimeSpeed = 1.5f;
    public static float SlimeDetectionRadius=100;

    public static float Mob2Speed = 3;
    public static float Mob2DetectionRange = 100;
    
    public static float RangedMobSpeed = 1.5f;
    public static float RangedMobDetectionRadius = 100;

    public static int SlimeHP = 20;

    public static int Mob2HP = 20;

    public static int RangedMobHP = 20;

    public static Color defaultSlimeColor = Color.white;
    public static Color defaultMob2Color = Color.white;
    public static Color defaultRangedMobColor = Color.black;

    public static int SlimeBurnDuration = 5;
    public static int Mob2BurnDuration = 5;
    public static int RangedMobBurnDuration = 5;

    public static int SlimeSlowDuration = 8;
    public static int Mob2SlowDuration = 8;
    public static int RangedMobSlowDuration = 8;
   

    public static int SlimeFreezeDuration = 5;
    public static int Mob2FreezeDuration = 5;
    public static int RangedMobFreezeDuration = 5;

    public static int FireSpell1FlatDamage = 5;
    public static int IceSpell1FlatDamage = 5;
    public static int LightningSpell1Damage = 3;
    public static int HealSpell1Heal = 2;
    public static int MeleeAttackDamage = 3;
    
    public static int FireSpell2FlatDamage = 7;
    public static int IceSpell2FlatDamage = 7;
    public static int LightningSpell2Damage = 6;
    public static int HealSpell2Heal = 4;
    
    public static int FireSpell3DFlatDamage = 10;
    public static int IceSpell3FlatDamage = 10;
    public static int HealSpell3Heal = 3;

    public static int Lightning1EnemiesHit = 3;
    public static int Lightning2EnemiesHit = 6;
    
    public static int AttackBuff1Length = 5;
    public static int AttackBuff2Length = 7;

    public static float MinSecondsBeforeNextSlimeBurn = 1;
    public static float MaxSecondsBeforeNextSlimeBurn = 3;
    
    public static float MinSecondsBeforeNextMob2Burn = 1;
    public static float MaxSecondsBeforeNextMob2Burn = 3;
    
    public static float MinSecondsBeforeNextRangedMobBurn = 1;
    public static float MaxSecondsBeforeNextRangedMobBurn = 3;

    public static int MinNumberSlimesPerWave = 1;
    public static int MaxNumberSlimesPerWave = 2;
    
    public static int MinNumberMob2sPerWave = 0;
    public static int MaxNumberMob2sPerWave = 1;
    
    public static int MinNumberRangedMobsPerWave = 1;
    public static int MaxNumberRangedMobsPerWave = 2;
    
    public static float MinSecondsUntilSlimeFreeze = 3;
    public static float MaxSecondsUntilSlimeFreeze = 7;

    public static float MinSecondsUntilMob2Freeze = 5;
    public static float MaxSecondsUntilMob2Freeze = 10;
    
    public static float MinSecondsUntilRangedMobFreeze = 3;
    public static float MaxSecondsUntilRangedMobFreeze = 7;

    public static float MapMinX = -20; //left
    public static float MapMaxX = 25; //right

    public static float MapMinY = -12; //down
    public static float MapMaxY = 12; //up

    public static float DiceMinNumber = 1;
    public static float DiceMaxNumber = 7;
    public static float DiceRollWaitTime = 2f;
    
    public static float DiceSpellIconBuffer = 1f;
    
    public static float SpellCastWaitTime = 2f;
    
    //start of projectile and ranged parameters
    public static float ProjectileSpeed = 350f;
    public static float ProjectileLifespan = 5f;
    public static float InstantiateProjectileCooldown = 8f;
    public static float DelayTimeBeforeShooting = 2f;
    public static float DelayTimeAfterShooting = 2f;
    
    public static float MinDistanceFromGambit = 3f;
    public static float MaxDistanceToMoveToGambit = 6f; 
    public static float MinShootDistance = 3f;
    public static float MaxShootDistance = 3.5f;

    public static float ShootTolerance = 1f; // buffer zone to avoid flickering btwn shoot conditions
    
    public static bool CanKnockbackSlime = true;  
    public static float SlimeKnockbackCooldown = 1f;
    
    public static bool CanKnockbackMob2 = true;
    public static float Mob2KnockbackCooldown = 1f;
    
    public static bool CanKnockbackRangedMob = true;  
    public static float RangedMobKnockbackCooldown = 1f;

}

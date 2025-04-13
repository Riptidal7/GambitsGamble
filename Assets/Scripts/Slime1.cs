using System.Collections;
using UnityEngine;

public class Slime1 : Enemy
{

    private void Start()
    {
        enemySpeed = GameParameters.Mob2Speed;
        currentEnemySpeed = enemySpeed;
        detectionRadius = GameParameters.Mob2DetectionRange;
        minSecondsUntilFreeze = GameParameters.MinSecondsUntilMob2Freeze;
        maxSecondsUntilFreeze = GameParameters.MaxSecondsUntilMob2Freeze;
        HitPoints = GameParameters.Mob2HP;
        minSecondsUntilNextBurn = GameParameters.MinSecondsBeforeNextMob2Burn;
        maxSecondsUntilNextBurn = GameParameters.MaxSecondsBeforeNextMob2Burn;
        burnDuration = GameParameters.Mob2BurnDuration;
        defaultColor = GameParameters.defaultMob2Color;
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
        slowDuration = GameParameters.Mob2SlowDuration;
    }
    
    
}

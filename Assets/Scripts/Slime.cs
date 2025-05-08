using System.Collections;
using UnityEngine;

public class Slime : Enemy
{
    
    private void Start()
    {
        
        
        enemySpeed = GameParameters.SlimeSpeed;
        currentEnemySpeed = enemySpeed;
        detectionRadius = GameParameters.SlimeDetectionRadius;
        minSecondsUntilFreeze = GameParameters.MinSecondsUntilSlimeFreeze;
        maxSecondsUntilFreeze = GameParameters.MaxSecondsUntilSlimeFreeze;
        HitPoints = GameParameters.SlimeHP;
        minSecondsUntilNextBurn = GameParameters.MinSecondsBeforeNextSlimeBurn;
        maxSecondsUntilNextBurn = GameParameters.MaxSecondsBeforeNextSlimeBurn;
        burnDuration = GameParameters.SlimeBurnDuration;
        defaultColor = GameParameters.defaultSlimeColor;
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
        slowDuration = GameParameters.SlimeSlowDuration;
        freezeDuration = GameParameters.SlimeFreezeDuration;
    }
    
}

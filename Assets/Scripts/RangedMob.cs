using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RangedMob : Enemy
{
    private float minDistanceFromGambit = 250;
    public GameObject projectilePrefab;

    private bool canInstantiateProjectile = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    // Update is called once per frame
    void Update()
    {
        ///SET SPEED TO 0 RATHER THAN MAKING NEW MOVE METHOD
    
        if(canInstantiateProjectile)
        {
            print("mob is shooting bc it is close enough");
            InstantiateProjectile();
            StartCoroutine(CooldownToInstantiateProjectile());
        }
        
        
    }

    private void InstantiateProjectile()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    IEnumerator CooldownToInstantiateProjectile()
    {
        canInstantiateProjectile = false;
        yield return new WaitForSeconds(5f);
        canInstantiateProjectile = true;
    }
}

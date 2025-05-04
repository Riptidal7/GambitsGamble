using System.Collections;
using UnityEngine;

public class HealSpell : SpellParent
{
    //make spellflatdamage = 0 
    public Player Player; 
    public HPDisplayer HPDisplayer;
    public GameObject healAnimation;
    
    public void CastHealSpellFirstLevel()
    {
        if (Player.HitPoints < GameParameters.InitialMaxPlayerHitPoints-GameParameters.HealSpell1Heal)
        {
            Player.HitPoints+=GameParameters.HealSpell1Heal;
            HPDisplayer.UpdateHP(Player.HitPoints);
            PlayAnimation();
        }
    }

    public void CastHealSpellSecondLevel()
    {
        if (Player.HitPoints < GameParameters.InitialMaxPlayerHitPoints-GameParameters.HealSpell1Heal)
        {
            Player.HitPoints+=GameParameters.HealSpell2Heal;
            HPDisplayer.UpdateHP(Player.HitPoints);
            PlayAnimation();
        }
    }

    private void HealThePlayer()
    {
        Player.HitPoints++;
        HPDisplayer.UpdateHP(Player.HitPoints);
    }

    private void PlayAnimation()
    {
       // print("animating");
        GameObject heal = Instantiate(healAnimation, Player.transform.position, Quaternion.identity);
        heal.transform.SetParent(Player.transform);
        StartCoroutine(CountdownUntilAnimationOver(heal));
    }

    IEnumerator CountdownUntilAnimationOver(GameObject healToDestroy)
    {
        yield return new WaitForSeconds(1);
        Destroy(healToDestroy);
    }
}

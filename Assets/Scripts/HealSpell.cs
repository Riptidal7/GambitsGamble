using UnityEngine;

public class HealSpell : MonoBehaviour
{
    public Player Player;
    public HPDisplayer HPDisplayer;

    public void CastHealSpellFirstLevel()
    {
        if (Player.HitPoints < GameParameters.InitialMaxPlayerHitPoints-GameParameters.HealSpell1Heal)
        {
            Player.HitPoints+=GameParameters.HealSpell1Heal;
            HPDisplayer.UpdateHP(Player.HitPoints);
        }
    }

    public void CastHealSpellSecondLevel()
    {
        if (Player.HitPoints < GameParameters.InitialMaxPlayerHitPoints-GameParameters.HealSpell1Heal)
        {
            Player.HitPoints+=GameParameters.HealSpell2Heal;
            HPDisplayer.UpdateHP(Player.HitPoints);
        }
    }

    private void HealThePlayer()
    {
        Player.HitPoints++;
        HPDisplayer.UpdateHP(Player.HitPoints);
    }
}

using UnityEngine;

public class HealSpell : MonoBehaviour
{
    public Player Player;
    public HPDisplayer HPDisplayer;

    public void CastHealSpellFirstLevel()
    {
        if (Player.HitPoints < 5)
        {
            HealThePlayer();
            
        }
    }

    private void HealThePlayer()
    {
        Player.HitPoints++;
        HPDisplayer.UpdateHP(Player.HitPoints);
    }
}

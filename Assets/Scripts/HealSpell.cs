using UnityEngine;

public class HealSpell : MonoBehaviour
{
    public Player Player;
    public HPDisplayer HPDisplayer;

    public void CastHealSpell()
    {
        Player.HitPoints++;
        HPDisplayer.UpdateHP(Player.HitPoints);
    }
}

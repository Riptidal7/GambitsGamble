using System.Collections;
using UnityEngine;

public class HealSpell : SpellParent
{
  
    public Player Player; 
    public HPDisplayer HPDisplayer;
    public int HealAmount;
    
    public bool CanPlayerHeal()
    {
        //PLEASE READ: this causes healing logic bug where u can't heal at a certain point under max health
        if (Player.HitPoints < GameParameters.InitialMaxPlayerHitPoints - HealAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void HealPlayer()
    {
        if (CanPlayerHeal())
        {
            Player.HitPoints += HealAmount;
            HPDisplayer.UpdateHP(Player.HitPoints);
        }
        

    }
    
    private void HealThePlayer()
    {
        Player.HitPoints++;
        HPDisplayer.UpdateHP(Player.HitPoints);
    }
    
    
    
    
}

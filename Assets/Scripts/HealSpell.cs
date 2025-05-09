using System.Collections;
using UnityEngine;

public class HealSpell : SpellParent
{
  
    public Player Player; 
    public HPDisplayer HPDisplayer;
    public int HealAmount;
    
    public bool CanPlayerHeal()
    {
        //PLEASE READ: this causes healing logic bug where u can't heal at a certain point under maxhealth
        //max health = 50
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
        AllowPlayerToHealIfHealSpellGoesOverMaxHealth();
        
        if (CanPlayerHeal())
        {
            Player.HitPoints += HealAmount;
            HPDisplayer.UpdateHP(Player.HitPoints);
        }

    }

    public void AllowPlayerToHealIfHealSpellGoesOverMaxHealth()
    {
        if (Player.HitPoints >= GameParameters.InitialMaxPlayerHitPoints - HealAmount)
        {
            Player.HitPoints = GameParameters.InitialMaxPlayerHitPoints;
            HPDisplayer.UpdateHP(Player.HitPoints);
        }
        
    }

    //be able to use heal spell until hit 5
        //if heal amount + playerhealth/hitpoints > initial max health then == initial max health
    
}

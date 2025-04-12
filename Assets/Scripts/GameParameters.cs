using UnityEngine;

public static class GameParameters
{
    //Charlotte: I'm pretty sure knockback has to be greater than movespeed or he'll vibrate forward anyway
    public static float PlayerMoveSpeed = 5f;
    public static float PlayerConstraintKnockback = 0.05f;

    public static int InitialMaxPlayerHitPoints = 5;

    public static float MapMinX = -10;
    public static float MapMaxX = 10;

    public static float MapMinY = -10;
    public static float MapMaxY = 10;

    public static float DiceMinNumber = 1;
    public static float DiceMaxNumber = 7;
    public static float DiceRollWaitTime = 2f;
    
    public static float SpellCastWaitTime = 2f;
}

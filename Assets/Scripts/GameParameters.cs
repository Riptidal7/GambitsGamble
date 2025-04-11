using UnityEngine;

public static class GameParameters
{
    //Charlotte: I'm pretty sure knockback has to be greater than movespeed or he'll vibrate forward anyway
    public static float PlayerMoveSpeed = 0.04f;
    public static float PlayerConstraintKnockback = 0.05f;

    public static int InitialMaxPlayerHitPoints = 5;

    public static int SecondsOfInvulnerabilityAfterDamage = 1;

    public static float MapMinX = -10;
    public static float MapMaxX = 10;

    public static float MapMinY = -10;
    public static float MapMaxY = 10;
}

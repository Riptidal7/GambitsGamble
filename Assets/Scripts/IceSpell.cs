public class IceSpell : SpellParent
{
    protected override void Start()
    {
        SpellFlatDamage = GameParameters.FireSpell1DFlatDamage;
        base.Start();
    }

    protected override void OnEnemyHit(Enemy enemy)
    {
        enemy.isSlowed = true;
    }
}
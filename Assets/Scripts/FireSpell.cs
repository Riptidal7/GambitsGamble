public class FireSpell : SpellParent
{
    protected override void Start()
    {
        SpellFlatDamage = GameParameters.FireSpell1FlatDamage;
        base.Start();
    }

    protected override void OnEnemyHit(Enemy enemy)
    {
        enemy.isBurning = true;
    }
}
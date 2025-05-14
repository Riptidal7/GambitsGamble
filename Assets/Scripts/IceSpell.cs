public class IceSpell : SpellParent
{
    protected override void Start()
    {
        SpellFlatDamage = GameParameters.IceSpell1FlatDamage;
        base.Start();
    }

    protected override void OnEnemyHit(Enemy enemy)
    {
        enemy.isSlowed = true;
    }
}
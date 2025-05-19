using UnityEngine;

public class WindSpell : SpellParent
{
    public Player Gambit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
        if (Gambit == null)
        {
            Gambit = FindObjectOfType<Player>();
            Debug.Log("Found him!");
        }
    }

    protected override void OnEnemyHit(Enemy enemy)
    {
        DirectionType direction = Gambit.direction;
        Vector2 knockbackDirection = Vector2.zero;

        // Check for Slime
        if (enemy.gameObject.CompareTag("Slime"))
        {
            Slime slime = enemy.GetComponent<Slime>();
            slime.HitPoints -= GameParameters.MeleeAttackDamage;

            if (!slime.canKnockback)
                return;

            KnockbackFeedback knockback = slime.GetComponent<KnockbackFeedback>();
            if (knockback != null)
            {
                knockback.AssignAOEKnockbackDirection(Gambit.transform.position, slime.transform.position, ref knockbackDirection);
                knockback.ApplyKnockback(direction, knockbackDirection);
            }

            slime.StartKnockbackCooldown();
        }
        // Check for Mob2
        else if (enemy.gameObject.CompareTag("Mob2"))
        {
            Slime1 slime1 = enemy.GetComponent<Slime1>();
            slime1.HitPoints -= GameParameters.MeleeAttackDamage;

            if (!slime1.canKnockback)
                return;

            KnockbackFeedback knockback = slime1.GetComponent<KnockbackFeedback>();
            if (knockback != null)
            {
                knockback.AssignAOEKnockbackDirection(Gambit.transform.position, slime1.transform.position, ref knockbackDirection);
                knockback.ApplyKnockback(direction, knockbackDirection);
            }

            slime1.StartKnockbackCooldown();
        }
        // Check for RangedMob
        else if (enemy.gameObject.CompareTag("RangedMob"))
        {
            RangedMob rangedMob = enemy.GetComponent<RangedMob>();
            rangedMob.HitPoints -= GameParameters.MeleeAttackDamage;

            if (!rangedMob.canKnockback)
                return;

            KnockbackFeedback knockback = rangedMob.GetComponent<KnockbackFeedback>();
            if (knockback != null)
            {
                knockback.AssignAOEKnockbackDirection(Gambit.transform.position, rangedMob.transform.position, ref knockbackDirection);
                knockback.ApplyKnockback(direction, knockbackDirection);
            }

            rangedMob.StartKnockbackCooldown();
        }
    }

}

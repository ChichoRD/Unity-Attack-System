using System.Collections.Generic;
using UnityEngine;

public class Trigger2DAttackInstance : TriggerAttackInstance
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckTrigger(collision.gameObject);
    }

    protected override void DisableTriggerWithIgnored(IEnumerable<IDamageable> damageables)
    {
        var colliders2D = GetComponents<Collider2D>();

        foreach (var damageable in damageables)
        {
            if (damageable is not Component c || !c.TryGetComponent(out Collider2D damageableCollider)) return;

            foreach (var rigidbodyCollider in colliders2D)
                Physics2D.IgnoreCollision(rigidbodyCollider, damageableCollider);
        }
    }
}

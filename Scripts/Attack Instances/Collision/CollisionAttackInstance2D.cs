using System.Collections.Generic;
using UnityEngine;

public class CollisionAttackInstance2D : CollisionAttackInstance
{    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckCollision(collision.gameObject);
    }

    protected override void DisableCollisionWithIgnored(IEnumerable<IDamageable> damageables)
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
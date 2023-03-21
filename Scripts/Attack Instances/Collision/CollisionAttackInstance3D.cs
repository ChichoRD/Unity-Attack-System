using System.Collections.Generic;
using UnityEngine;

public class CollisionAttackInstance3D : CollisionAttackInstance
{
    private void OnCollisionEnter(Collision collision)
    {
        CheckCollision(collision.gameObject);
    }

    protected override void DisableCollisionWithIgnored(IEnumerable<IDamageable> damageables)
    {
        var colliders = GetComponents<Collider>();
        
        foreach (var damageable in damageables)
        {
            if (damageable is not Component c || !c.TryGetComponent(out Collider damageableCollider)) return;

            foreach (var rigidbodyCollider in colliders)
                Physics.IgnoreCollision(rigidbodyCollider, damageableCollider);
        }
    }
}
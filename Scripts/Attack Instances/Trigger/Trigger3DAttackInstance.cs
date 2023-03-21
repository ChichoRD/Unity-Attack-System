using System.Collections.Generic;
using UnityEngine;

public class Trigger3DAttackInstance : TriggerAttackInstance
{
    private void OnTriggerEnter(Collider collision)
    {
        CheckTrigger(collision.gameObject);
    }

    protected override void DisableTriggerWithIgnored(IEnumerable<IDamageable> damageables)
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

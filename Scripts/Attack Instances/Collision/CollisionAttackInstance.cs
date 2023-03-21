using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public abstract class CollisionAttackInstance : MonoBehaviour, IHitteableAttackInstance
{
    [RequireInterface(typeof(IAttackInstanceInfoProvider))]
    [SerializeField] private Object _attackInstanceInfoObject;
    public IAttackInstanceInfoProvider AttackInstanceInfoProvider => _attackInstanceInfoObject as IAttackInstanceInfoProvider;
    private IAttackDamageablesInfoProvider _attackDamageablesInfoProvider;
    public Component Component => this;
    [field: SerializeField] public UnityEvent OnAttackLaunched { get; private set; }

    [field: SerializeField] public UnityEvent OnHit { get; private set; }
    [field: SerializeField] public UnityEvent OnMiss { get; private set; }
    [field: SerializeField] public bool AllowSelfDamage { get; private set; }

    public virtual void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders)
    {
        foreach (var provider in attackControllerInfoProviders)
        {
            _attackDamageablesInfoProvider ??= provider as IAttackDamageablesInfoProvider;

            if (_attackDamageablesInfoProvider == null) continue;
            DisableCollisionWithIgnored(_attackDamageablesInfoProvider.IgnoredDamageables);
        }
    }

    public void Launch()
    {
        OnAttackLaunched?.Invoke();
    }

    protected bool CheckCollision(GameObject collisionGameObject)
    {
        if (((1 << collisionGameObject.layer) & AttackInstanceInfoProvider.LayerMask) == 0
            || !collisionGameObject.TryGetComponent(out IDamageable damageable)
            || (!AllowSelfDamage && _attackDamageablesInfoProvider != null && _attackDamageablesInfoProvider.AssociatedDamageables.Contains(damageable)))
        {
            OnMiss?.Invoke();
            return false;
        }

        damageable.TakeDamage(AttackInstanceInfoProvider.GetDamage());
        OnHit?.Invoke();
        return true;
    }

    protected abstract void DisableCollisionWithIgnored(IEnumerable<IDamageable> damageables);
}
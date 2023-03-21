using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class RigidbodyAttackInstance : MonoBehaviour, IAttackInstance
{
    [RequireInterface(typeof(IAttackInstanceInfoProvider))]
    [SerializeField] private Object _attackInstanceInfoObject;
    public IAttackInstanceInfoProvider AttackInstanceInfoProvider => _attackInstanceInfoObject as IAttackInstanceInfoProvider;
    [field: SerializeField] public bool AllowSelfDamage { get; private set; }
    public Component Component => this;
    [field: SerializeField] public UnityEvent OnAttackLaunched { get; private set; }

    public abstract void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders);

    public void Launch()
    {
        OnAttackLaunched.Invoke();
    }

    public abstract void ApplyForce(Vector3 force);
    public abstract void MoveBody(Vector3 position);
    public abstract float GetMass();
}
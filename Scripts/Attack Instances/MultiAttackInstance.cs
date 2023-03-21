using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class MultiAttackInstance : MonoBehaviour, IAttackInstance
{
    [SerializeField] private Object[] _attackInstanceObjects;
    public IAttackInstance[] AttackInstances => _attackInstanceObjects.Select(obj => obj as IAttackInstance).ToArray();

    [field: SerializeField] public bool AllowSelfDamage { get; private set; }
    public IAttackInstanceInfoProvider AttackInstanceInfoProvider => AttackInstances[0].AttackInstanceInfoProvider;
    public Component Component => this;
    [field: SerializeField] public UnityEvent OnAttackLaunched { get; private set; }


    public void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders)
    {
        foreach (var instance in AttackInstances)
        {
            instance.OnAttackLaunched.AddListener(OnAttackLaunched.Invoke);
            instance.Initialise(attackControllerInfoProviders);
        }
    }

    public void Launch()
    {
        foreach (var instance in AttackInstances)
            instance.Launch();
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParentedAttackInstance : MonoBehaviour, IAttackInstance
{
    [RequireInterface(typeof(IAttackInstance))]
    [SerializeField] private Object _attackInstanceObject;
    public IAttackInstance AttackInstance => _attackInstanceObject as IAttackInstance;

    private IAttackParentInfoProvider _attackParentInfoProvider;
    private IAttackPositionInfoProvider _attackPositionInfoProvider;

    [SerializeField] private bool _setParentOnLaunch = true;
    [SerializeField] private bool _setPositionOnLaunch = true;

    public bool AllowSelfDamage => AttackInstance.AllowSelfDamage;
    public IAttackInstanceInfoProvider AttackInstanceInfoProvider => AttackInstance.AttackInstanceInfoProvider;
    public Component Component => AttackInstance.Component;
    public UnityEvent OnAttackLaunched => AttackInstance.OnAttackLaunched;

    public void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders)
    {
        AttackInstance.Initialise(attackControllerInfoProviders);

        foreach (var provider in attackControllerInfoProviders)
        {
            _attackParentInfoProvider ??= provider as IAttackParentInfoProvider;
            _attackPositionInfoProvider ??= provider as IAttackPositionInfoProvider;
        }
    }

    public void Launch()
    {
        SetParent();
        SetPosition();
        AttackInstance.Launch();
    }

    public void SetParent()
    {
        if (!_setParentOnLaunch || _attackParentInfoProvider == null) return;
        transform.SetParent(_attackParentInfoProvider.GetAttackParent());
    }

    public void SetPosition()
    {
        if (!_setPositionOnLaunch || _attackPositionInfoProvider == null) return;
        transform.position = _attackPositionInfoProvider.GetAttackPosition();
    }
}

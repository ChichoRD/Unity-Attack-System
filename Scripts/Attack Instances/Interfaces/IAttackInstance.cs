using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IAttackInstance
{
    bool AllowSelfDamage { get; }
    IAttackInstanceInfoProvider AttackInstanceInfoProvider { get; }
    Component Component { get; }
    UnityEvent OnAttackLaunched { get; }
    void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders);
    void Launch();
}

using System.Collections.Generic;
using UnityEngine.Events;

public interface IAttackController
{
    IAttackInstance AttackInstance { get; }
    UnityEvent<IAttackInstance> OnAttacked { get; }
    bool Attack();
    bool CancelAttack();
    void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders);
}

using System.Collections.Generic;
using UnityEngine.Events;

public interface IAttackController
{
    IAttackInstance AttackInstance { get; set; }
    UnityEvent<IAttackInstance> OnAttacked { get; }
    UnityEvent<IAttackInstance> OnAttackInstanceSet { get; }
    bool Attack();
    bool CancelAttack();
    void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders);
}

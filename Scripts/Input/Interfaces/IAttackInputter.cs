using System.Collections.Generic;
using UnityEngine.Events;

public interface IAttackInputter
{
    IAttackController AttackerController { get; }

    UnityEvent OnAttackInputDenied { get; }
    UnityEvent OnAttackCancelInputDenied { get; }

    void Attack();
    void CancelAttack();
    void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders);
}

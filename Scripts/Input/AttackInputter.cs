using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class AttackInputter : MonoBehaviour, IAttackInputter
{
    [RequireInterface(typeof(IAttackController))]
    [SerializeField] private Object _attackerController;
    public IAttackController AttackerController => _attackerController as IAttackController;

    [field: SerializeField] public UnityEvent OnAttackInputDenied { get; private set; }
    [field: SerializeField] public UnityEvent OnAttackCancelInputDenied { get; private set; }

    public void Attack()
    {
        if (AttackerController.Attack()) return;

        OnAttackInputDenied?.Invoke();
    }

    public void CancelAttack()
    {
        if (AttackerController.CancelAttack()) return;

        OnAttackCancelInputDenied?.Invoke();
    }

    public void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders)
    {
        AttackerController.Initialise(attackControllerInfoProviders);
    }
}

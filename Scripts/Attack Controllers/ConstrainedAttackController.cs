using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class ConstrainedAttackController : MonoBehaviour, IConstrainedAttackController
{
    [RequireInterface(typeof(IAttackController))]
    [SerializeField] private Object _attackerControllerObject;
    public IAttackController AttackerController => _attackerControllerObject as IAttackController;
    public IAttackInstance AttackInstance => AttackerController.AttackInstance;

    [RequireInterface(typeof(IAttackConstrainer))]
    [SerializeField] private Object _attackConstrainerObject;
    public IAttackConstrainer AttackConstrainer => _attackConstrainerObject as IAttackConstrainer;
    public UnityEvent<IAttackInstance> OnAttacked => AttackerController.OnAttacked;
    [field: SerializeField] public UnityEvent OnFailedToAttack { get; private set; }

    public bool Attack()
    {
        if (!AttackConstrainer.CanAttack())
        {
            OnFailedToAttack?.Invoke();
            return false;
        }
        
        return AttackerController.Attack();
    }

    public bool CancelAttack()
    {
        return AttackerController.CancelAttack();
    }

    public void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders)
    {
        AttackerController.Initialise(attackControllerInfoProviders);
        AttackConstrainer.Initialise(AttackerController);
    }
}
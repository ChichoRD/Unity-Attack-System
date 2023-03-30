using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class AttackInstancerController : MonoBehaviour, IAttackController
{
    [RequireInterface(typeof(IAttackInstance))]
    [SerializeField] private Object _attackInstanceSourceObject;
    private IAttackInstance _attackInstanceSource;

    [RequireInterface(typeof(IAttackController))]
    [SerializeField] private Object _attackerControllerObject;
    public IAttackController AttackController => _attackerControllerObject as IAttackController;
    public IAttackInstance AttackInstance { get => AttackController.AttackInstance; set => AttackController.AttackInstance = value; }
    public UnityEvent<IAttackInstance> OnAttacked => AttackController.OnAttacked;
    public UnityEvent<IAttackInstance> OnAttackInstanceSet => AttackController.OnAttackInstanceSet;

    public bool Attack()
    {
        AttackInstance = Instantiate(_attackInstanceSource.Component).GetComponents<IAttackInstance>().First(a => a.GetType() == _attackInstanceSource.GetType());
        return AttackController.Attack();
    }

    public bool CancelAttack()
    {
        return AttackController.CancelAttack();
    }

    public void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders)
    {
        _attackInstanceSource = _attackerControllerObject as IAttackInstance;
        AttackController.Initialise(attackControllerInfoProviders);
    }
}
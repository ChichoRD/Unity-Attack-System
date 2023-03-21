using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class AttackController : MonoBehaviour, IAttackController
{
    [RequireInterface(typeof(IAttackInstance))]
    [SerializeField] private Object _attackInstanceObject;
    public IAttackInstance AttackInstance => _attackInstanceObject as IAttackInstance;
    
    [field: SerializeField] public UnityEvent<IAttackInstance> OnAttacked { get; private set; }
    private List<IAttackControllerInfoProvider> _attackControllerInfoProviders;

    public bool Attack()
    {
        IAttackInstance attack = Instantiate(AttackInstance.Component).GetComponents<IAttackInstance>().First(a => a.GetType() == AttackInstance.GetType());
        attack.Initialise(_attackControllerInfoProviders);
        attack.Launch();
        OnAttacked?.Invoke(attack);
        return true;
    }

    public bool CancelAttack()
    {
        return true;//TODO
    }

    public void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders)
    {
        _attackControllerInfoProviders = new List<IAttackControllerInfoProvider>(attackControllerInfoProviders);
    }
}
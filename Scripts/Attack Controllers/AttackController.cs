using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackController : MonoBehaviour, IAttackController
{
    [RequireInterface(typeof(IAttackInstance))]
    [SerializeField] private Object _initalAttackInstanceObject;

    private IAttackInstance _attackInstance;
    public IAttackInstance AttackInstance 
    {
        get => _attackInstance;
        set
        {
            _attackInstance = value;
            OnAttackInstanceSet?.Invoke(value);
        }
    }
    
    [field: SerializeField] public UnityEvent<IAttackInstance> OnAttacked { get; private set; }
    [field: SerializeField] public UnityEvent<IAttackInstance> OnAttackInstanceSet { get; private set; }

    private List<IAttackControllerInfoProvider> _attackControllerInfoProviders;

    public bool Attack()
    {
        AttackInstance.Initialise(_attackControllerInfoProviders);
        AttackInstance.Launch();
        OnAttacked?.Invoke(AttackInstance);
        return true;
    }

    public bool CancelAttack()
    {
        return true;//TODO
    }

    public void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders)
    {
        AttackInstance ??= _initalAttackInstanceObject as IAttackInstance;
        _attackControllerInfoProviders = new List<IAttackControllerInfoProvider>(attackControllerInfoProviders);
    }
}

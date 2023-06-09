﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class ConstrainedAttackController : MonoBehaviour, IConstrainedAttackController
{
    [RequireInterface(typeof(IAttackController))]
    [SerializeField] private Object _attackerControllerObject;
    public IAttackController AttackController => _attackerControllerObject as IAttackController;
    public IAttackInstance AttackInstance { get => AttackController.AttackInstance; set => AttackController.AttackInstance = value; }

    [RequireInterface(typeof(IAttackConstrainer))]
    [SerializeField] private Object _attackConstrainerObject;
    public IAttackConstrainer AttackConstrainer => _attackConstrainerObject as IAttackConstrainer;
    public UnityEvent<IAttackInstance> OnAttacked => AttackController.OnAttacked;
    public UnityEvent<IAttackInstance> OnAttackInstanceSet => AttackController.OnAttackInstanceSet;
    [field: SerializeField] public UnityEvent OnFailedToAttack { get; private set; }

    public bool Attack()
    {
        if (!AttackConstrainer.CanAttack())
        {
            OnFailedToAttack?.Invoke();
            return false;
        }
        
        return AttackController.Attack();
    }

    public bool CancelAttack()
    {
        return AttackController.CancelAttack();
    }

    public void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders)
    {
        AttackController.Initialise(attackControllerInfoProviders);
        AttackConstrainer.Initialise(AttackController);
    }
}
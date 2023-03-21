using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SerialisedAttackSetHandler : AttackSetHandler
{
    [SerializeField] private Object[] _attackControllerInfoProviders;
    public IEnumerable<IAttackControllerInfoProvider> AttackControllerInfoProvider => _attackControllerInfoProviders.Select(a => a as IAttackControllerInfoProvider);

    public override void InitialiseAttackController()
    {
        if (AttackInputter == null) return;

        AttackInputter.Initialise(AttackControllerInfoProvider);
    }
}
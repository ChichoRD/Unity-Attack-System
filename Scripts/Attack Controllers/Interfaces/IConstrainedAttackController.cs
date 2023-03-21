using UnityEngine.Events;

interface IConstrainedAttackController : IAttackController
{
    IAttackConstrainer AttackConstrainer { get; }

    UnityEvent OnFailedToAttack { get; }
}
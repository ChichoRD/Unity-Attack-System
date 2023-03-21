using UnityEngine.Events;

public interface IHitteableAttackInstance : IAttackInstance
{
    UnityEvent OnHit { get; }
    UnityEvent OnMiss { get; }
}
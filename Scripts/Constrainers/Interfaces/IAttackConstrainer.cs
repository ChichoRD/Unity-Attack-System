using UnityEngine.Events;

public interface IAttackConstrainer
{
    UnityEvent OnAttackAbilityLost { get; }
    UnityEvent OnAttackAbilityRestored { get; }
    bool CanAttack();
    void Initialise(IAttackController attacker);
}
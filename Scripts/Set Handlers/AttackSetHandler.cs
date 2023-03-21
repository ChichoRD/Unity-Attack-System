using UnityEngine;

public abstract class AttackSetHandler : MonoBehaviour, IAttackSetHandler
{
    [RequireInterface(typeof(IAttackInputter))]
    [SerializeField] private Object _attackInputter;
    public IAttackInputter AttackInputter => _attackInputter as IAttackInputter;

    public abstract void InitialiseAttackController();

    private void OnValidate()
    {
        InitialiseAttackController();
    }
}

using UnityEngine;

public class AttackOriginSetterSetHandler : MonoBehaviour, IAttackSetHandler, IAttackParentInfoProvider, IAttackPositionInfoProvider
{
    [SerializeField] private AttackSetHandler _attackSetHandler;
    [SerializeField] private Transform _attackOrigin;
    [SerializeField] private bool _spawnOnAwake;

    public IAttackInputter AttackInputter => ((IAttackSetHandler)_attackSetHandler).AttackInputter;
    public IAttackController Owner => AttackInputter.AttackerController;

    private void Awake()
    {
        if (!_spawnOnAwake) return;

        AttackInputter.Attack();
    }

    public Vector3 GetAttackPosition()
    {
        return _attackOrigin.position;
    }

    public void InitialiseAttackController()
    {
        ((IAttackSetHandler)_attackSetHandler).InitialiseAttackController();
    }

    public Transform GetAttackParent()
    {
        return _attackOrigin;
    }
}

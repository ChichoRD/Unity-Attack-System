using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AttackSetHandler))]
public class PlayerAimedAttackSetHandler : MonoBehaviour, IAttackSetHandler, IAttackControllerInfoProvider, IAttackOriginInfoProvider, IAttackDirectionInfoProvider, IAttackMagnitudeInfoProvider, IAttackPositionInfoProvider
{
    [SerializeField] private AttackSetHandler _attackSetHandler;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _attackOrigin;
    [SerializeField] private InputActionReference _attackActionReference;

    public IAttackInputter AttackInputter => ((IAttackSetHandler)_attackSetHandler).AttackInputter;
    public IAttackController Owner => AttackInputter.AttackerController;

    private void Awake()
    {
        _attackActionReference.action.performed += OnAttackPerformed;
    }

    private void OnEnable()
    {
        _attackActionReference.action.Enable();
    }

    private void OnDisable()
    {
        _attackActionReference.action.Disable();
    }

    private void OnDestroy()
    {
        _attackActionReference.action.performed -= OnAttackPerformed;
    }

    private void OnAttackPerformed(InputAction.CallbackContext obj)
    {
        AttackInputter.Attack();
    }

    public Vector3 GetAttackDirection()
    {
        Vector2 screenPosition = _attackActionReference.action.ReadValue<Vector2>();
        Vector3 attackPosition = _camera.ScreenToWorldPoint(screenPosition);

        Vector3 direction = (attackPosition - _attackOrigin.position).normalized;
        return direction;
    }

    public float GetAttackMagnitude()
    {
        Vector2 screenPosition = _attackActionReference.action.ReadValue<Vector2>();
        Vector3 attackPosition = _camera.ScreenToWorldPoint(screenPosition);

        Vector3 direction = (attackPosition - _attackOrigin.position);
        return direction.magnitude;
    }

    public Vector3 GetAttackPosition()
    {
        Vector2 screenPosition = _attackActionReference.action.ReadValue<Vector2>();
        Vector3 attackPosition = _camera.ScreenToWorldPoint(screenPosition);

        return attackPosition;
    }

    public Vector3 GetAttackOrigin()
    {
        return _attackOrigin.position;
    }

    public void InitialiseAttackController()
    {
        ((IAttackSetHandler)_attackSetHandler).InitialiseAttackController();
    }
}

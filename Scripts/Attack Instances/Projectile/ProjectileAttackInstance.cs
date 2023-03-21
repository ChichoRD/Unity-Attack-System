using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RigidbodyAttackInstance))]
public class ProjectileAttackInstance : MonoBehaviour, IHitteableAttackInstance
{
    [RequireInterface(typeof(IHitteableAttackInstance))]
    [SerializeField] private Object _hitteableAttackInstanceObject;
    public IHitteableAttackInstance HitteableAttackInstance => _hitteableAttackInstanceObject as IHitteableAttackInstance;

    public UnityEvent OnHit => HitteableAttackInstance.OnHit;
    public UnityEvent OnMiss => HitteableAttackInstance.OnMiss;

    [SerializeField] private RigidbodyAttackInstance _rigidbodyAttackInstance;
    private IAttackOriginInfoProvider _originProvider;
    private IAttackMagnitudeInfoProvider _magnitudeProvider;
    private IAttackDirectionInfoProvider _directionProvider;

    public IAttackInstanceInfoProvider AttackInstanceInfoProvider => ((IAttackInstance)_rigidbodyAttackInstance).AttackInstanceInfoProvider;
    public Component Component => this;
    public UnityEvent OnAttackLaunched => ((IAttackInstance)_rigidbodyAttackInstance).OnAttackLaunched;
    public bool AllowSelfDamage => ((IAttackInstance)_rigidbodyAttackInstance).AllowSelfDamage;

    public void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders)
    {
        HitteableAttackInstance.Initialise(attackControllerInfoProviders);
        _rigidbodyAttackInstance.Initialise(attackControllerInfoProviders);

        foreach (var provider in attackControllerInfoProviders)
        {
            _originProvider ??= provider as IAttackOriginInfoProvider;
            _directionProvider ??= provider as IAttackDirectionInfoProvider;
            _magnitudeProvider ??= provider as IAttackMagnitudeInfoProvider;
        }
    }

    public void Launch()
    {
        Vector3 launchPosition = GetLaunchPosition();
        Vector3 launchForce = GetLaunchForce(_rigidbodyAttackInstance.GetMass());

        _rigidbodyAttackInstance.MoveBody(launchPosition);//Body Attack Instance
        _rigidbodyAttackInstance.ApplyForce(launchForce);
        
        OnAttackLaunched?.Invoke();
    }

    protected Vector3 GetLaunchPosition()
    {
        return _originProvider.GetAttackOrigin();
    }

    protected Vector3 GetLaunchForce(float mass)
    {
        //m * dv = f *dt
        //f = m * dv / dt
        return   mass * (1f / Time.fixedDeltaTime) * _magnitudeProvider.GetAttackMagnitude() * _directionProvider.GetAttackDirection();
    }
}
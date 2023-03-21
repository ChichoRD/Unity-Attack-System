using System.Collections.Generic;
using UnityEngine;

public class Rigidbody3DAttackInstance : RigidbodyAttackInstance
{
    [SerializeField] private Rigidbody _rigidbody;
    //public Rigidbody Rigidbody => _rigidbody;

    public override void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders)
    {
        _rigidbody = _rigidbody != null ? _rigidbody : GetComponent<Rigidbody>();
    }

    public override void ApplyForce(Vector3 force)
    {
        _rigidbody.AddForce(force);
    }

    public override void MoveBody(Vector3 position)
    {
        _rigidbody.position = position;
    }

    public override float GetMass()
    {
        return _rigidbody.mass;
    }
}

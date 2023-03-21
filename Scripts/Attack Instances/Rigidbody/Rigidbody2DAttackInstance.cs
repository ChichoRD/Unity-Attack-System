using System.Collections.Generic;
using UnityEngine;

public class Rigidbody2DAttackInstance : RigidbodyAttackInstance
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    //public Rigidbody2D Rigidbody2D => _rigidbody2D;

    public override void Initialise(IEnumerable<IAttackControllerInfoProvider> attackControllerInfoProviders)
    {
        _rigidbody2D = _rigidbody2D != null ? _rigidbody2D : GetComponent<Rigidbody2D>();
    }

    public override void ApplyForce(Vector3 force)
    {
        _rigidbody2D.AddForce(force);
    }

    public override void MoveBody(Vector3 position)
    {
        _rigidbody2D.position = position;
    }

    public override float GetMass()
    {
        return _rigidbody2D.mass;
    }
}

using UnityEngine;

public interface IAttackDirectionInfoProvider : IAttackControllerInfoProvider
{
    Vector3 GetAttackDirection();
}

using UnityEngine;

public interface IAttackPositionInfoProvider : IAttackControllerInfoProvider
{
    Vector3 GetAttackPosition();
}

using UnityEngine;

public interface IAttackOriginInfoProvider : IAttackControllerInfoProvider
{
    Vector3 GetAttackOrigin();
}

using UnityEngine;

public interface IAttackParentInfoProvider : IAttackControllerInfoProvider
{
    Transform GetAttackParent();
}

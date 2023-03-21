using UnityEngine;

public interface IAttackInstanceInfoProvider
{
    float GetDamage();
    LayerMask LayerMask { get; }
}
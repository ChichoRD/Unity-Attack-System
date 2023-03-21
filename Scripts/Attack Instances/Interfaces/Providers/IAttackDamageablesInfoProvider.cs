using System.Collections.Generic;

public interface IAttackDamageablesInfoProvider : IAttackControllerInfoProvider
{
    IEnumerable<IDamageable> IgnoredDamageables { get; }
    IEnumerable<IDamageable> AssociatedDamageables { get; }
}
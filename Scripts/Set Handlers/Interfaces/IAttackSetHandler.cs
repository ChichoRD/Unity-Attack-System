using System;

interface IAttackSetHandler
{
    IAttackInputter AttackInputter { get; }
    void InitialiseAttackController();
}

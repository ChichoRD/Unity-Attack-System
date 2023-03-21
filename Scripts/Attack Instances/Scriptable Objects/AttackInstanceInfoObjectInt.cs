using UnityEngine;

[CreateAssetMenu(fileName = NAME + SPACE + INT_VARIANT, menuName = PATH + NAME + SLASH + INT_VARIANT)]
public class AttackInstanceInfoObjectInt : AttackInstanceInfoObject
{
    [SerializeField] private int _attackDamage;
    public override float GetDamage() => _attackDamage;
}

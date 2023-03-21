using UnityEngine;

[CreateAssetMenu(fileName = NAME + SPACE + FLOAT_VARIANT, menuName = PATH + NAME + SLASH + FLOAT_VARIANT)]
public class AttackInstanceInfoObjectFloat : AttackInstanceInfoObject
{
    [SerializeField] private float _attackDamage;
    public override float GetDamage() => _attackDamage;
}

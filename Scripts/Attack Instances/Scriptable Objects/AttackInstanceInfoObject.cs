using UnityEngine;

[CreateAssetMenu(fileName = NAME, menuName = PATH + NAME)]
public abstract class AttackInstanceInfoObject : ScriptableObject, IAttackInstanceInfoProvider
{
    protected const string PATH = "Attack Instances/Scriptable Objects/";
    protected const string NAME = "Attack Info";

    protected const string SPACE = " ";
    protected const string SLASH = "/";

    protected const string INT_VARIANT = "Int Variant";
    protected const string FLOAT_VARIANT = "Float Variant";

    [SerializeField] private LayerMask _layerMask;

    public abstract float GetDamage();
    public LayerMask LayerMask => _layerMask;
}

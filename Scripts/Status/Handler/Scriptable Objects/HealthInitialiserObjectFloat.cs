using UnityEngine;

[CreateAssetMenu(fileName = BASE_NAME + SPACE + FLOAT_VARIANT, menuName = PATH + SLASH + FLOAT_VARIANT)]
public class HealthInitialiserObjectFloat : HealthInitialiserObject
{
    [field: SerializeField] public float InitialHealth { get; protected set; }
    [field: SerializeField] public float MaxHealth { get; protected set; }
    [field: SerializeField] public float MinHealth { get; protected set; }

    public override float GetInitialHealth() => InitialHealth;
    public override float GetMaxHealth() => MaxHealth;
    public override float GetMinHealth() => MinHealth;
}
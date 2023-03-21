using UnityEngine;

[CreateAssetMenu(fileName = BASE_NAME + SPACE + INT_VARIANT, menuName = PATH + SLASH + INT_VARIANT)]
public class HealthInitialiserObjectInt : HealthInitialiserObject
{
    [field: SerializeField] public int InitialHealth { get; protected set; }
    [field: SerializeField] public int MaxHealth { get; protected set; }
    [field: SerializeField] public int MinHealth { get; protected set; }

    public override float GetInitialHealth() => InitialHealth;
    public override float GetMaxHealth() => MaxHealth;
    public override float GetMinHealth() => MinHealth;
}

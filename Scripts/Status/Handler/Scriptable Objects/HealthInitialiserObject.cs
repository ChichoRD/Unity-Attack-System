using UnityEngine;

public abstract class HealthInitialiserObject : ScriptableObject
{
    protected const string PATH = "Scriptable Objects/Health Initialiser";
    protected const string BASE_NAME = "New Health Initialiser";

    protected const string INT_VARIANT = "Int Variant";
    protected const string FLOAT_VARIANT = "Float Variant";

    protected const string SPACE = " ";
    protected const string SLASH = "/";

    public abstract float GetInitialHealth();
    public abstract float GetMaxHealth();
    public abstract float GetMinHealth();
}
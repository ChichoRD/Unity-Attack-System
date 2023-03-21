using UnityEngine;

public class HealthDisplayerFloat : HealthDisplayer
{
    protected override void UpdateHealthDisplay(float health)
    {
        //TODO
        Debug.Log(health);
    }
}
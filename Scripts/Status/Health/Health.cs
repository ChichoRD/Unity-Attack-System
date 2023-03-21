using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct Health
{
    private float _healthPoints;

    public float HealthPoints 
    { 
        get => _healthPoints; 
        set
        {
            _healthPoints = value;
            OnHealthChanged?.Invoke(_healthPoints);
        }
    }
    
    [field: SerializeField] public UnityEvent<float> OnHealthChanged { get; private set; }
    
    public void Initialise(float healthPoints)
    {
        HealthPoints = healthPoints;
    }
}

using UnityEngine;
using UnityEngine.Events;

public class StatusHandler : MonoBehaviour, IDamageable, IHealable
{
    [SerializeField] protected HealthInitialiserObject healthInitialiser;
    [SerializeField] protected Health health;

    [field: SerializeField] public UnityEvent OnHealthReachedMinimun { get; protected set; }
    [field: SerializeField] public UnityEvent OnHealthReachedMaximum { get; protected set; }

    public Health Health { get => health; }

    protected virtual void Awake()
    {
        health.Initialise(healthInitialiser.GetInitialHealth());
    }

    protected bool HealSurpassesMaximun(float heal)
    {
        float total = health.HealthPoints + heal;
        return total > healthInitialiser.GetMaxHealth();
    }

    protected bool DamageSurpassesMinimun(float damage)
    {
        float total = health.HealthPoints - damage;
        return total < healthInitialiser.GetMinHealth();
    }

    public void Heal(float heal)
    {
        if (HealSurpassesMaximun(heal))
        {
            OnHealthReachedMaximum?.Invoke();
            health.HealthPoints = healthInitialiser.GetMaxHealth();
            return;
        }
        
        health.HealthPoints += heal;
    }

    public void TakeDamage(float damage)
    {
        if (DamageSurpassesMinimun(damage))
        {
            OnHealthReachedMinimun?.Invoke();
            health.HealthPoints = healthInitialiser.GetMinHealth();
            return;
        }
        
        health.HealthPoints -= damage;
    }
}
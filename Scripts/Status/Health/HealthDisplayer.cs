using UnityEngine;

public abstract class HealthDisplayer : MonoBehaviour
{
    [SerializeField] private StatusHandler _statusHandler;

    protected virtual void Awake()
    {
        _statusHandler.Health.OnHealthChanged.AddListener(UpdateHealthDisplay);
    }

    protected abstract void UpdateHealthDisplay(float health);
}
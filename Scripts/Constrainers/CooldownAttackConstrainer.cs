using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CooldownAttackConstrainer : MonoBehaviour, IAttackConstrainer
{
    public float RemainingCooldown { get; private set; }
    [SerializeField][Min(0)] private float _cooldown;
    [SerializeField] private bool _invertProgress;
    [SerializeField] private bool _enableAttackOnCooldownInterrupted = true;
    private Coroutine _cooldownCoroutine;

    private bool _cooledDown = true;
    public bool CooledDown
    {
        get => _cooledDown;
        private set
        {
            bool wasCooledDown = _cooledDown;
            _cooledDown = value;

            if (wasCooledDown && !_cooledDown)
                OnAttackAbilityLost?.Invoke();
            if (!wasCooledDown && _cooledDown)
                OnAttackAbilityRestored?.Invoke();
        }
    }

    [field: SerializeField] public UnityEvent OnAttackAbilityLost { get; private set; }
    [field: SerializeField] public UnityEvent OnAttackAbilityRestored { get; private set; }
    [field: SerializeField] public UnityEvent<float> OnCoolingDown { get; private set; }

    public bool CanAttack() => CooledDown;

    public void Initialise(IAttackController attacker)
    {
        attacker.OnAttacked.AddListener(StartCooldown);

        void StartCooldown(IAttackInstance _) => this.StartCooldown();
    }

    private void StartCooldown() => _cooldownCoroutine ??= StartCoroutine(CooldownCoroutine());

    public void StopCooldown()
    {
        if (_cooldownCoroutine == null) return;
        StopCoroutine(_cooldownCoroutine);
        _cooldownCoroutine = null;

        CooledDown |= _enableAttackOnCooldownInterrupted;
    }

    private IEnumerator CooldownCoroutine()
    {
        RemainingCooldown = _cooldown;
        Func<float> getCooldownPercentage = _invertProgress ?
            () => 1 - RemainingCooldown / _cooldown :
            () => RemainingCooldown / _cooldown;
        CooledDown = false;

        while (RemainingCooldown > 0)
        {
            float cooldownPercentage = getCooldownPercentage();
            OnCoolingDown?.Invoke(cooldownPercentage);

            RemainingCooldown -= Time.deltaTime;
            yield return null;
        }

        RemainingCooldown = 0;
        CooledDown = true;
        _cooldownCoroutine = null;
    }
}

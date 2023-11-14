using System;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    [SerializeField] private float _hp;

    [SerializeField] private float _shieldPower;

    public float CurrentHP
    {
        get { return _hp; }
        set
        {
            _hp = value;

            if (_hp > MaxHP)
            {
                _hp = MaxHP;
            }
            OnHPChange?.Invoke();
        }
    }

    public float MaxHP => _maxHP;

    public Action OnDead;
    public Action OnHPChange;

    private void Awake()
    {
        _hp = _maxHP;
    }

    public void TakeDamage(float damage)
    {
        if (damage > _shieldPower)
        {
            damage -= _shieldPower;
            _shieldPower = 0;
        }
        else
        {
            _shieldPower -= damage;
            damage = 0;
        }
        CurrentHP -= damage;

        if (CurrentHP <= 0)
        {
            OnDead?.Invoke();
        }
    }

    public void TurnOnShield(float power)
    {
        _shieldPower = power;
    }

    public void TurnOffShield()
    {
        _shieldPower = 0;
    }
}

using System;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    [SerializeField] private float _hp;

    [SerializeField] private float _shieldPower;

    public float CurrentHP => _hp;
    public float MaxHP => _maxHP;

    public Action OnDead;
    public Action OnTakeDamage;

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
        _hp -= damage;
        OnTakeDamage?.Invoke();

        if (_hp <= 0)
        {
            OnDead?.Invoke();
        }
    }

    public void TurnOnShield(int power)
    {
        _shieldPower = power;
    }

    public void TurnOffShield()
    {
        _shieldPower = 0;
    }
}

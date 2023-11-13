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
        }
    }

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

    public void TurnOnShield(float power)
    {
        _shieldPower = power;
    }

    public void TurnOffShield()
    {
        _shieldPower = 0;
    }
}

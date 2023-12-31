using System;
using System.Collections;
using UnityEngine;

public class ProtectionSpell : Spell
{
    [SerializeField] private HP _target;

    [SerializeField] private Action _OnEndCallback;

    public override void Activate(Action OnEndCallback = null)
    {
        if (PersonType == PersonType.Me)
        {
            _target.TurnOnShield(SpellsData.Instance.MyProtection);
        }
        else
        {
            _target.TurnOnShield(SpellsData.Instance.EnemyProtection);
        }

        _OnEndCallback = OnEndCallback;
        _animator.Play("VictoryStart");

        StartCoroutine(MakeShield(_delay));
    }

    private IEnumerator MakeShield(float delay)
    {
        yield return new WaitForSeconds(delay);
        _effect.SetActive(true);

        yield return new WaitForSeconds(_duration);

        yield return null;
        _OnEndCallback?.Invoke();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _target.TurnOffShield();
    }
}

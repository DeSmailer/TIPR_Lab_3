using System;
using System.Collections;
using UnityEngine;

public class HealSpell : Spell
{
    [SerializeField] private HP _target;

    [SerializeField] private Action _OnEndCallback;

    public override void Activate(Action OnEndCallback = null)
    {
        if (PersonType == PersonType.Me)
        {
            _target.CurrentHP += SpellsData.Instance.MyHeal;
        }
        else
        {
            _target.CurrentHP += SpellsData.Instance.EnemyHeal;
        }

        _OnEndCallback = OnEndCallback;
        _animator.Play("");

        StartCoroutine(MakeHeal(_delay));
    }

    private IEnumerator MakeHeal(float delay)
    {
        yield return new WaitForSeconds(delay);
        _effect.SetActive(true);

        yield return null;
        _OnEndCallback?.Invoke();
    }
}

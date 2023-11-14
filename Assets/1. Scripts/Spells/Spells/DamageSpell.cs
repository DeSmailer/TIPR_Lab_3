using System;
using System.Collections;
using UnityEngine;

public class DamageSpell : Spell
{
    [SerializeField] private HP _target;

    [SerializeField] private Action _OnEndCallback;

    public override void Activate(Action OnEndCallback = null)
    {
        _OnEndCallback = OnEndCallback;
        _animator.Play("");

        StartCoroutine(MakeDamage());
    }

    private IEnumerator MakeDamage()
    {
        yield return new WaitForSeconds(_delay);
        _effect.gameObject.SetActive(true);

        if (PersonType == PersonType.Me)
        {
            _target.TakeDamage(SpellsData.Instance.MyDamage);
        }
        else
        {
            _target.TakeDamage(SpellsData.Instance.EnemyDamage);
        }

        yield return new WaitForSeconds(_duration);

        _effect.gameObject.SetActive(false);
        _OnEndCallback?.Invoke();
    }
}

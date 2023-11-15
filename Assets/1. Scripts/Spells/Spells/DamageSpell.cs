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
        _animator.Play("Attack02Start");

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
        yield return new WaitForSeconds(0.1f);
        _animator.Play("Idle03");

        _OnEndCallback?.Invoke();
    }
}

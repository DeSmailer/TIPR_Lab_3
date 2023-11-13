using System;
using System.Collections;
using UnityEngine;

public class DamageSpell : Spell
{
    [SerializeField] private HP _target;

    [SerializeField] private Action _OnEndCallback;

    public override void Activate(Action OnEndCallback = null)
    {
        _effect.SetActive(true);
        _OnEndCallback = OnEndCallback;
        _animator.Play("");

        StartCoroutine(MakeDamage(_delay));
    }

    private IEnumerator MakeDamage(float delay)
    {
        yield return new WaitForSeconds(delay);

        _target.TakeDamage(SpellsData.Instance.MyDamage);

        yield return null;
        _OnEndCallback?.Invoke();
    }
}

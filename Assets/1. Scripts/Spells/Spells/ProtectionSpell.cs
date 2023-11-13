using System;
using System.Collections;
using UnityEngine;

public class ProtectionSpell : Spell
{
    [SerializeField] private HP _target;

    [SerializeField] private Action _OnEndCallback;

    public override void Activate(Action OnEndCallback = null)
    {
        _target.TurnOnShield
            TakeDamage(SpellsData.Instance.MyDamage);
        _OnEndCallback = OnEndCallback;
        _animator.Play("");

        StartCoroutine(MakeDamage(_delay));
    }

    private IEnumerator MakeDamage(float delay)
    {
        yield return new WaitForSeconds(delay);
        _effect.SetActive(true);


        yield return null;
        _OnEndCallback?.Invoke();
    }
}

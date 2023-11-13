using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpell : Spell
{
    [SerializeField] private HP _target;
    [SerializeField] private GameObject _effect;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _delay;

    public override void Activate()
    {
        _effect.SetActive(true);
        StartCoroutine(MakeDamage(_delay));
    }

    private IEnumerator MakeDamage(float delay)
    {
        yield return new WaitForSeconds(delay);

        _target.TakeDamage(SpellsData.Instance.MyDamage);

        yield return null;
    }
}

using System;
using UnityEngine;

public abstract class Spell : MonoBehaviour, ISpell
{
    [SerializeField] protected GameObject _effect;
    [SerializeField] protected Sprite _sprite;
    [SerializeField] protected Animator _animator;

    [SerializeField] protected float _delay;

    public Sprite Sprite => _sprite;

    public abstract void Activate(Action OnEndCallback = null);
    public virtual void Deactivate()
    {
        _effect.SetActive(false);
        _animator.Play("Idle");
    }
}

public enum SpellType
{
    Damage,
    Protection,
    Heal,
    Copying
}

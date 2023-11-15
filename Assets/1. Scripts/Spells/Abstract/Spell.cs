using System;
using UnityEngine;

public abstract class Spell : MonoBehaviour, ISpell
{
    [SerializeField] protected GameObject _effect;
    [SerializeField] protected Sprite _sprite;
    [SerializeField] protected Animator _animator;

    [SerializeField] protected float _delay;
    [SerializeField] protected float _duration;

    [SerializeField] protected SpellType _spellType;
    [SerializeField] protected PersonType _personType;

    public Sprite Sprite => _sprite;
    public SpellType SpellType => _spellType;
    public PersonType PersonType => _personType;

    public abstract void Activate(Action OnEndCallback = null);
    public virtual void Deactivate()
    {
        _effect.gameObject.SetActive(false);
        _animator.Play("Idle03");
    }
}

public enum SpellType
{
    Damage,
    Protection,
    Heal,
    Copying
}

public enum PersonType
{
    Me,
    Enemy
}

using System;
using UnityEngine;

public class CopyingSpell : Spell
{
    [SerializeField] private DamageSpell _damageSpell;
    [SerializeField] private ProtectionSpell _protectionSpell;
    [SerializeField] private HealSpell _healSpell;

    [SerializeField] private Spell _currentSpell;

    [SerializeField] private Action _OnEndCallback;

    public void Activate(SpellType spellType, Action OnEndCallback = null)
    {
        switch (spellType)
        {
            case SpellType.Damage:
                _currentSpell = _damageSpell;
                break;
            case SpellType.Protection:
                _currentSpell = _protectionSpell; ;
                break;
            case SpellType.Heal:
                _currentSpell = _healSpell;
                break;
            default:
                break;
        }

        Activate(OnEndCallback);
    }

    public override void Activate(Action OnEndCallback = null)
    {
        _currentSpell.Activate(OnEndCallback);
    }

    public override void Deactivate()
    {
        if (_currentSpell != null)
        {
            _currentSpell.Deactivate();
        }
        _currentSpell = null;
        _animator.Play("Idle03");
    }
}

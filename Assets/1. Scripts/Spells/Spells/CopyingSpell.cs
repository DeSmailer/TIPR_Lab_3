using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyingSpell : Spell
{
    [SerializeField] private HP _target;

    [SerializeField] private Action _OnEndCallback;

    public void Activate(Spell spell, Action OnEndCallback = null)
    {
        spell.Activate(OnEndCallback);
    }

    public override void Activate(Action OnEndCallback = null)
    {
        
    }
}

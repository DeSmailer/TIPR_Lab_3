using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedSpells : MonoBehaviour
{
    [SerializeField] private List<Outline> _outlines;

    [SerializeField] private List<Spell> _spells;
    [SerializeField] private int _selectedSpellIndex;

    public ISpell SelectedSpell => _spells[_selectedSpellIndex];

    public void SelectSpell(int index)
    {
        _selectedSpellIndex = index;

        foreach (var item in _outlines)
        {
            item.enabled = false;
        }

        _outlines[_selectedSpellIndex].enabled = true;
    }
}

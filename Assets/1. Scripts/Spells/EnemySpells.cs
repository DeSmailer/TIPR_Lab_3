using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpells : MonoBehaviour
{
    [SerializeField] private List<Spell> _spells;
    [SerializeField] private int _selectedSpellIndex;

    [SerializeField] private int _minIndex = 0;
    [SerializeField] private int _maxIndex = 4;

    public Spell SelectedSpell
    {
        get
        {
            _selectedSpellIndex = Random.Range(_minIndex, _maxIndex);

            return _spells[_selectedSpellIndex];
        }
    }

    public void ResetSpells()
    {
        _selectedSpellIndex = -1;

        foreach (var item in _spells)
        {
            item.Deactivate();
        }
    }
}

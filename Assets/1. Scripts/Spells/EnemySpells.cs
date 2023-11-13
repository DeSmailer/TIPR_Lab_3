using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpells : MonoBehaviour
{
    [SerializeField] private List<Spell> _spells;
    [SerializeField] private int _selectedSpellIndex;

    public Spell SelectedSpell
    {
        get
        {
            _selectedSpellIndex = Random.Range(0, 4);

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

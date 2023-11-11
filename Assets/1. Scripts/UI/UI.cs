using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private SpellsPowerUI _spellsPowerUI;
    [SerializeField] private SpellsPowerComparisonUI _spellsPowerComparisonUI;
    [SerializeField] private SpellsPowerSummaryComparisonUI _spellsPowerSummaryComparisonUI;

    public void Initialize()
    {
        _spellsPowerUI.Initialize();
        _spellsPowerComparisonUI.Initialize();
        _spellsPowerSummaryComparisonUI.Initialize();
    }
}

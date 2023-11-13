using UnityEngine;
using TMPro;
using System;

public class SpellsPowerUI : MonoBehaviour
{
    [SerializeField] private SpellsPowerCell _myDamageInputField;
    [SerializeField] private SpellsPowerCell _myProtectionInputField;
    [SerializeField] private SpellsPowerCell _myHealInputField;

    [SerializeField] private SpellsPowerCell _enemyDamageInputField;
    [SerializeField] private SpellsPowerCell _enemyProtectionInputField;
    [SerializeField] private SpellsPowerCell _enemyHealInputField;

    public void Initialize()
    {
        SetSpellsData();
        SubscribeToEvent();
    }

    private void SetSpellsData()
    {
        float _myDamage = _myDamageInputField.GetValue();
        float _myProtection = _myProtectionInputField.GetValue();
        float _myHeal = _myHealInputField.GetValue();

        float _enemyDamage = _enemyDamageInputField.GetValue();
        float _enemyProtection = _enemyProtectionInputField.GetValue();
        float _enemyHeal = _enemyHealInputField.GetValue();

        SpellsData.Instance.SetData(_myDamage, _myProtection, _myHeal, _enemyDamage, _enemyProtection, _enemyHeal);
    }

    private void SubscribeToEvent()
    {
        _myDamageInputField.OnDeselect += SetSpellsData;
        _myProtectionInputField.OnDeselect += SetSpellsData;
        _myHealInputField.OnDeselect += SetSpellsData;

        _enemyDamageInputField.OnDeselect += SetSpellsData;
        _enemyProtectionInputField.OnDeselect += SetSpellsData;
        _enemyHealInputField.OnDeselect += SetSpellsData;
    }

    private void UnsubscribeFromEvent()
    {
        _myDamageInputField.OnDeselect -= SetSpellsData;
        _myProtectionInputField.OnDeselect -= SetSpellsData;
        _myHealInputField.OnDeselect -= SetSpellsData;

        _enemyDamageInputField.OnDeselect -= SetSpellsData;
        _enemyProtectionInputField.OnDeselect -= SetSpellsData;
        _enemyHealInputField.OnDeselect -= SetSpellsData;
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvent();
    }
}

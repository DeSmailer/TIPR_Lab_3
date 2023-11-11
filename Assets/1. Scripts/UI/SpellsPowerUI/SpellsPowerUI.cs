using UnityEngine;
using TMPro;

public class SpellsPowerUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField _myDamageInputField;
    [SerializeField] private TMP_InputField _myProtectionInputField;
    [SerializeField] private TMP_InputField _myHealInputField;

    [SerializeField] private TMP_InputField _enemyDamageInputField;
    [SerializeField] private TMP_InputField _enemyProtectionInputField;
    [SerializeField] private TMP_InputField _enemyHealInputField;

    public void Initialize()
    {
        float _myDamage = float.Parse(_myDamageInputField.text);
        float _myProtection = float.Parse(_myProtectionInputField.text);
        float _myHeal = float.Parse(_myHealInputField.text);

        float _enemyDamage = float.Parse(_enemyDamageInputField.text);
        float _enemyProtection = float.Parse(_enemyProtectionInputField.text);
        float _enemyHeal = float.Parse(_enemyHealInputField.text);


        SpellsData.Instance.SetData(_myDamage, _myProtection, _myHeal, _enemyDamage, _enemyProtection, _enemyHeal);
    }
}

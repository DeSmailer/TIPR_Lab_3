using UnityEngine;
using TMPro;
using System;

public class SpellsPowerCell : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    public Action OnDeselect;

    private void Start()
    {
        _inputField.onDeselect.AddListener(OnDeselectHandler);
    }

    public void OnDeselectHandler(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            _inputField.text = "0";
        }

        OnDeselect?.Invoke();
    }

    public float GetValue()
    {
        return float.Parse(_inputField.text);
    }
}

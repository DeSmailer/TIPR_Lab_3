using UnityEngine;
using TMPro;

public class IntegerOnly : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TMP_InputField>().characterValidation = TMP_InputField.CharacterValidation.Integer;
    }
}

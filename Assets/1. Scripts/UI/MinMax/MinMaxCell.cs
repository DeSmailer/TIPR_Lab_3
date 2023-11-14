using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinMaxCell : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _color;

    [SerializeField] private TMP_Text _text;

    public void Fill(float value, bool paint)
    {
        _image.color = _defaultColor;

        if (paint)
        {
            _image.color = _color;
        }
        _text.text = value.ToString();
    }
}
